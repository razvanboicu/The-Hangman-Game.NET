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
        public void CreateUser(User user)
        {
            try
            {
                UserCreated?.Invoke(user);
                using (StreamWriter writer = File.AppendText(pathFile))
                {
                    writer.WriteLine(user.username + " " + user.password);
                    Console.WriteLine("Successfully new user created");
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
            List<Tuple<string, string>> playersFromFile = new List<Tuple<string, string>>();
            temp = System.IO.File.ReadAllLines(@"E:\the-hangman-game\the-hangman-game.NET\TheHangmanGame\Services\Users.txt");
            for (int i = 0; i < temp.Length / 2; i += 2)
            {
                playersFromFile.Add(new Tuple<string, string>(temp[i], temp[i + 1]));
            }
            foreach (Tuple<string, string> user in playersFromFile)
            {
                if (user.Item1 == searchedUser.username && user.Item2 == searchedUser.password)
                    return true;
            }
            return false;

        }
    }
}
