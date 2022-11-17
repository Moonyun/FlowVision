using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.common;
using WpfApp1.model;

namespace WpfApp1.windowmodel
{
    public class MainWindowModel:NotifyBase

    {
        public UserModel UserInfo { get; set; }         //用户信息
        public CommandBase NavChanged { get; set; }        //主按钮选择子界面

        public MainWindowModel()
        {
            UserInfo = new UserModel();
            this.NavChanged = new CommandBase();
            this.NavChanged.DoExecute = new Action<object>(DoNavChanged);
            this.NavChanged.DoCanExecute = new Func<object, bool>((o) => true);
            DoNavChanged("FirstPage");            //初始化默认首页
        }

        private void DoNavChanged(object obj)
        {
            Type type = Type.GetType("WpfApp1.window." + obj.ToString());
            ConstructorInfo cti = type.GetConstructor(System.Type.EmptyTypes);
            this.MainContent = (FrameworkElement)cti.Invoke(null);
        }


        //窗口栏下方子界面
        private FrameworkElement _maincontent;
        public FrameworkElement MainContent
        {
            get { return _maincontent; }
            set { _maincontent = value; this.DoNotify(); }
        }


    }
}
