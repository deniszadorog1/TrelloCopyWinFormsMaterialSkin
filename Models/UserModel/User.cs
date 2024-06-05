using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrelloCopyWinForms.Models.Enums;

namespace TrelloCopyWinForms.Models.UserModel
{
    public class User
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
        public AccountType? Type { get; set; }

        public User()
        {
            Login = string.Empty;
            Email = string.Empty;
            Id = -1;
            Password = string.Empty;
        }
        public User(string login, string email, string password)
        {
            Login = login;
            Email = email;
            Password = password;      
        }
        public User(string login, string email, int id)
        {
            Login = login;
            Email = email;
            Id = id;
            Password = string.Empty;
        }
    }
}
