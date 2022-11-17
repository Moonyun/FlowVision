using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.common;
using WpfApp1.model;

namespace WpfApp1.model
{
    public class LoginModel : NotifyBase
    {
        private string username;
        public string Username { 
            get { return username; } 
            set { username = value;
                this.DoNotify();
            } }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; this.DoNotify(); }
        }
    }
}
