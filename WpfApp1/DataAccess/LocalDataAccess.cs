using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using WpfApp1.DataAccess.DataEntity;
using System.Data;

namespace WpfApp1.DataAccess
{
    //连接用户信息数据库验证
    public class LocalDataAccess
    {
        private static LocalDataAccess instance;
        private LocalDataAccess() { }
        public static LocalDataAccess GetInstance()
        {
            return instance ?? (instance = new LocalDataAccess());
        }

        SqlConnection conn;   //数据库链接
        SqlCommand cmd;
        SqlDataAdapter adapter;

        public void dispose()
        {
            if(adapter != null)
            {
                adapter.Dispose();
                adapter = null;
            }
            if (cmd != null)
            {
                cmd.Dispose();
                cmd = null;
            }
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }            
        }

        //connection 初始化，连接数据库
        private bool DBconnection()
        {
            string connsql = ConfigurationManager.ConnectionStrings["db"].ConnectionString; 
            if(conn == null)
            {
                conn = new SqlConnection(connsql);
            }
            try
            {
                conn.Open(); 
                
                return true;
            }
            catch 
            {
                return false;
            }
        }

        //验证用户信息是否正确，外部传入username和password做验证
        public UserEntity CheckUserInfo(string username, string pwd)
        {
            try
            {
                if (DBconnection())
                {

                    string usersSQL = "select * from Users where UserName=@UserName and Password=@pwd";
                    adapter = new SqlDataAdapter(usersSQL, conn);
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar) { Value = username });
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@pwd", SqlDbType.VarChar) { Value = pwd });

                    DataTable table = new DataTable();
                    int colnum = adapter.Fill(table);

                    if (colnum <= 0)
                        throw new Exception("用户名或密码不正确！");
                    else
                    {
                        DataRow dr = table.Rows[0];         //用户信息提取
                        UserEntity userEntity = new UserEntity();
                        userEntity.Id = dr.Field<int>("Id");
                        userEntity.UserName = dr.Field<string>("UserName");
                        userEntity.Password = dr.Field<string>("Password");
                        userEntity.group = dr.Field<int>("group");
                        return userEntity;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally 
            {
                this.dispose();   //关闭数据库
            }
            return null;
        }

        //数据库操作
        
        public int Execute(string insqlstring)         //更新数据库
        {
            DBconnection();
            cmd = new SqlCommand(insqlstring, conn);
            int n = cmd.ExecuteNonQuery();
            return n;
        }
        public SqlDataReader reader()   //读取数据库
        {

            if (DBconnection())
            {
                string usersSQL = "select * from Users";
                cmd = new SqlCommand(usersSQL, conn);
            }
            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
            
        }

    }
}
