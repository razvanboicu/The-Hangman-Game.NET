using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHangmanGame.Models;

namespace TheHangmanGame.Stores
{
    public class UserStore
    {
        public event Action<User> UserCreated;
        private string pathFile = @"E:\the-hangman-game\the-hangman-game.NET\TheHangmanGame\Services\Users.txt";

        public UserStore() { }
        public void UpdateAvatarProfile(User user)
        {
            string[] temp;
            temp = System.IO.File.ReadAllLines(@pathFile);
            string searchedUser = user.username + " " + user.password;


        }
        public void CreateUser(User user)
        {
            try
            {
                if (!SearchUser(user))
                {
                    UserCreated?.Invoke(user);
                    using (StreamWriter writer = File.AppendText(pathFile))
                    {
                        writer.WriteLine(user.username + " " + user.password + " #");
                        Console.WriteLine("Successfully new user created");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public bool SearchUser(User searchedUser)
        {
            // Console.Write("DA FRATE SUNT AICI");
            string[] temp;
            List<Tuple<string, string, string>> playersFromFile = new List<Tuple<string, string, string>>();
            temp = System.IO.File.ReadAllLines(@pathFile);
            foreach (string it in temp)
            {
                string[] userAndPassword = it.Split(' ');
                if (userAndPassword[0] == searchedUser.username && userAndPassword[1] == searchedUser.password)
                    return true;
            }
            return false;

        }
    }
}
