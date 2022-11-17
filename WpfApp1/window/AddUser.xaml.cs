using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.DataAccess;

namespace WpfApp1.window
{
    /// <summary>
    /// AddUser.xaml 的交互逻辑
    /// </summary>
    public partial class AddUser : Window
    {
        private string _erroemessage ;   //错误消息提示
        public AddUser()
        {
            InitializeComponent();
            
        }
       

        //确认添加按钮
        private void ConfirmAdd_Click(object sender, RoutedEventArgs e)
        {
            if(InputUsername.Text != "" && InputPassword.Password != "")
            {
                if(InputPassword.Password != ConfirmPassword.Password)
                {
                    _erroemessage = "请确保密码输入一致!";
                    MessageBox.Show(_erroemessage);
                }
                else
                {
                    string sqlstr = $"insert into Users(UserName,Password,[Group]) values ('{InputUsername.Text}','{InputPassword.DataContext}',1)";
                    int n = LocalDataAccess.GetInstance().Execute(sqlstr);
                    if(n > 0)
                    {
                        MessageBox.Show("添加成功!");
                    }
                    else { MessageBox.Show("添加失败!"); }
                    LocalDataAccess.GetInstance().dispose();    //关闭数据库
                }
                
            }
            else
            {
                _erroemessage = "用户名或密码不能为空!";
                MessageBox.Show(_erroemessage);
            }
            
        }

        //取消，关闭窗口
        private void Unadd_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
