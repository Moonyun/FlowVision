using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using WpfApp1.common;
using WpfApp1.model;
using WpfApp1.DataAccess;

namespace WpfApp1.windowmodel
{
    public class LoginWindowModel:NotifyBase
    {
        public LoginModel LoginModel { get; set; } = new LoginModel();
        public CommandBase CloseWindowCommand { get; set; }
        public CommandBase LoginCommand { get; set; }
        private string _errorMessage;

        public string ErrorMessage     //登录错误提示消息
        {
            get { return _errorMessage; }
            set { _errorMessage = value; this.DoNotify();}
        }


        public LoginWindowModel()
        {
 
            //关闭按钮
            
            this.CloseWindowCommand = new CommandBase();
            this.CloseWindowCommand.DoCanExecute = new Func<object, bool>((o)=> { return true; });
            this.CloseWindowCommand.DoExecute = new Action<object>((o) =>
            {
                (o as Window).Close();
            });

            //登录按钮
            this.LoginCommand = new CommandBase();
            this.LoginCommand.DoCanExecute = new Func<object, bool>((o)=> { return true; });
            this.LoginCommand.DoExecute = new Action<object>(DoLogin);


        }

        //登录验证
        private void DoLogin(object o)
        {
            this.ErrorMessage = "";            //初始化错误提示为空
            if (string.IsNullOrEmpty(LoginModel.Username))
            {
                this.ErrorMessage = "请输入用户名！";
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.Password))
            {
                this.ErrorMessage = "请输入密码！";
                return;
            }

            //异步连接数据库验证账户和密码
            Task.Run(new Action(() =>
            {
                try
                {
                    var user = LocalDataAccess.GetInstance().CheckUserInfo(LoginModel.Username, LoginModel.Password);
                    if (user == null)
                    {
                        throw new Exception("用户名或密码不正确!");
                    }

                    GlobalValues.UserInfo = user;      //全局变量，传入
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        (o as Window).DialogResult = true;
                    }));

            }
                catch (Exception ex)
                {
                    this.ErrorMessage = ex.Message;
                }
                return;
            }
            ));

        }
    }
        
}
