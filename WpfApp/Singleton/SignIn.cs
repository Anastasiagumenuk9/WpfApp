using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Singleton
{
    class SignIn
    {
        public User User { get; set; }
        public void Sign(string osName)
        {
            User = User.getInstance(osName);
        }
    }
}
