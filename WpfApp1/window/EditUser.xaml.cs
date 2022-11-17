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
    /// EditUser.xaml 的交互逻辑
    /// </summary>
    public partial class EditUser : Window
    {
        private string userId;
        public EditUser(string id,string username)  //传入变量，用户id，用户名
        {
            InitializeComponent();
            userId = id;
            InputUsername.Text = username;
        }

        //提交修改用户信息
        private void ConfirmEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = InputUsername.Text;
                string password = InputPassword.Password;
                string passwordconfirm = ConfirmPassword.Password;
                if (username == "" || password == "")
                {
                    throw new Exception("用户名或密码不能为空!");
                }
                else
                {
                    if(password!=passwordconfirm)
                    {
                        throw new Exception("请确保密码输入正确!");
                    }
                    else
                    {
                        string sqlstr = $"update Users set UserName ='{username}', Password ='{password}',[group] = 1 where Id ={userId}"; //更新数据库命令
                        int n = LocalDataAccess.GetInstance().Execute(sqlstr);
                        if (n > 0)
                        {
                            MessageBox.Show("修改成功!");
                        }
                        else
                        {
                            MessageBox.Show("修改失败!");
                        }
                        LocalDataAccess.GetInstance().dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
