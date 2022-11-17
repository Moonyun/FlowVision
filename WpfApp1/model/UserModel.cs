using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.common;

namespace WpfApp1.model
{
    public class UserModel:NotifyBase
    {
        private string _username;

        public string UserName
        {
            get { return _username; }
            set { _username = value; this.DoNotify(); }
        }

        private string _group;

        public string Group
        {
            get { return _group; }
            set { _group = value; this.DoNotify(); }
        }

    }
}
