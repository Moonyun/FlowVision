using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.common;

namespace WpfApp1.windowmodel
{
    public class SetupWindowModel:NotifyBase
    {
        public CommandBase SetpageChanged { get; set; }

        public SetupWindowModel()
        {
            this.SetpageChanged = new CommandBase();
            this.SetpageChanged.DoExecute = new Action<object>(DoSetpageChanged);
            this.SetpageChanged.DoCanExecute = new Func<object, bool>((o) => true);
            DoSetpageChanged("ComSetting");
        }

        private void DoSetpageChanged(object obj)
        {
            Type type = Type.GetType("WpfApp1.window." + obj.ToString());
            ConstructorInfo cti = type.GetConstructor(System.Type.EmptyTypes);
            this.Setpagecontent = (FrameworkElement)cti.Invoke(null);
        }


        //setup里选择子界面
        private FrameworkElement _Setpagecontent;
        public FrameworkElement Setpagecontent
        {
            get { return _Setpagecontent; }
            set { _Setpagecontent = value; this.DoNotify(); }
        }



    }
}
