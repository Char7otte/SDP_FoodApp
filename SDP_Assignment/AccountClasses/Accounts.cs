using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment.AccountClasses
{
    internal class Accounts
    {
        private List<Account> accounts;

        public Accounts() {
            accounts = [];
        }

        public Account register()
        {
            Console.WriteLine("Creating new account.");
            string? username = "";
            string? password = "";
            bool continueLoop = true;
            while (continueLoop)
            {
                continueLoop = false;
                Console.Write("Enter a username: ");
                username = Console.ReadLine();

                if (string.IsNullOrEmpty(username)) { 
                    continueLoop = true;
                    Console.WriteLine("Username cannot be empty.");
                    continue;
                }

                foreach (var account in accounts)
                {
                    if (account.Username.ToLower() == username.ToLower())
                    {
                        continueLoop = true;
                        Console.WriteLine("Username is already taken.");
                        break;
                    }
                }
            }

            while (true)
            {
                Console.Write("Enter a password: ");
                password = Console.ReadLine();
                break;
            }
            Account newAccount = new(username, password);
            addAccount(newAccount);
            return newAccount;
        }

        public Account? login()
        {
            Console.WriteLine("Logging in.");

            Console.Write("Enter your username: ");
            var username = Console.ReadLine();

            Console.Write("Enter your password ");
            var password = Console.ReadLine();

            foreach(var account in accounts)
            {
                if (account.Username == username && account.Password == password)
                {
                    return account;
                } 
            }

            Console.WriteLine("Invalid credentials. Please try again.");
            return null;
        }

        public void addAccount(Account account)
        {
            accounts.Add(account);
        }
    }
}
