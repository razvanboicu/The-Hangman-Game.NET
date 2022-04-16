using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHangmanGame.Models;

namespace TheHangmanGame.Stores
{
    public class UserStore
    {
        public event Action<User> UserCreated;
        public void CreateUser(User user)
        {
            try
            {
                UserCreated?.Invoke(user);
                Console.WriteLine("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
