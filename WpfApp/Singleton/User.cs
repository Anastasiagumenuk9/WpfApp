using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Singleton
{
    class User
    {
        private static User instance;

        public string Name { get; private set; }

        protected User(string name)
        {
            this.Name = name;
        }

        public static User getInstance(string name)
        {
            if (instance == null)
                instance = new User(name);
            return instance;
        }
    }
}
