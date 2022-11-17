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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.DataAccess;
using System.Data.SqlClient;
using System.Data;
using WpfApp1.window;
using WpfApp1.common;

namespace WpfApp1.window
{
    /// <summary>
    /// UserManage.xaml 的交互逻辑
    /// </summary>
    public partial class UserManage : UserControl
    {
        public UserManage()
        {
            InitializeComponent();
            DisplayTable();
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        //从数据库读取数据显示在表格中
        public void DisplayTable()
        {
            
            SqlDataReader dataReader = LocalDataAccess.GetInstance().reader();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID",typeof(string));
            dataTable.Columns.Add("Username", typeof(string));
            dataTable.Columns.Add("Password", typeof(string));
            dataTable.Columns.Add("Group", typeof(string));
            //取数据库里数据进入datatable
            while(dataReader.Read())
            {
                dataTable.Rows.Add(dataReader[0].ToString(), dataReader[1].ToString(), "********", dataReader[3].ToString());
            }
            LocalDataAccess.GetInstance().dispose();    //关闭数据库
            UserDataGrid.ItemsSource = dataTable.DefaultView;    //绑定数据，传入传输
           
        }

        //添加用户操作按钮
        private void adduser_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.ShowDialog();            
        }

        //删除用户操作
        private void deleteuser_Click(object sender, RoutedEventArgs e)
        {   
            try
            {
                DataRowView rowView = UserDataGrid.SelectedItem as DataRowView;
                if (rowView != null)
                {
                    string deleteId = rowView[0].ToString();
                    string deleteG = rowView[3].ToString();   //判断删除账户的类型
                    if (deleteG=="0")  //数据库中group为nchar10，这里多出了9个空格，0为管理员账户
                    {
                        throw new Exception("无法删除管理员账户！");
                    }
                    else    //非管理员账户可以删除
                    {
                        if(GlobalValues.UserInfo.Id == 0)
                        {
                            string sqlstr = $"delete from Users where Id='{deleteId}'";
                            int n = LocalDataAccess.GetInstance().Execute(sqlstr);
                            if (n > 0)
                            {
                                MessageBox.Show("删除成功!");
                            }
                            else
                            {
                                MessageBox.Show("无法删除该用户!");
                            }
                            LocalDataAccess.GetInstance().dispose();
                        }
                        else
                        {
                            throw new Exception("非管理员无法删除用户");
                        }                        
                    }                              
                }
                else
                {
                    MessageBox.Show("请选择删除的用户!");
                }                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //编辑用户信息
        private void edituser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView rowView = UserDataGrid.SelectedItem as DataRowView;
                if (rowView != null)
                {
                    string selectedId = rowView[0].ToString();
                    string userid = GlobalValues.UserInfo.Id.ToString();
                    if(userid==selectedId)
                    {
                        string username = rowView[1].ToString();
                        EditUser editUser = new EditUser(selectedId, username);
                        editUser.ShowDialog();
                    }
                    else
                    {
                        throw new Exception("您不是当前用户，不可编辑该用户!");
                    }
                }
                else
                {
                    throw new Exception("请选择编辑的用户!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
