using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHangmanGame.Models
{
    public class User
    {
        public string username { get; set; }  
        public string password { get; set; }
        public string avatarPath { get; set; }

        public User(string id, string pw)
        {
            username = id;
            password = pw;
        }

        public User() { }
    }
}
