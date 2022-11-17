using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.common
{
    public class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;  //事件

        public bool CanExecute(object parameter)     //可执行判断
        {
            return DoCanExecute?.Invoke(parameter) ==true;
        }

        public void Execute(object parameter)          //执行体
        {
            DoExecute?.Invoke(parameter);
        }

        public Action<object> DoExecute{ get; set; }
        public Func<object, bool> DoCanExecute { get; set; }
    }
}
