using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class User
    {
        private string password;
        private string name;
        private bool loggedin = false;
        public string Password { get; set; }
        public string Name { get; set; }

        public User(string password, string name)
        {
            Password = password; 
            Name = name;
        }

        public void login() {loggedin = true;}
        public void logout() {  loggedin = false; }
    }
}
