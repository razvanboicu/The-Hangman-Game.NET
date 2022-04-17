using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using TheHangmanGame.Models;
using ImgPath = System.Windows.Media.ImageSource;
namespace TheHangmanGame.Stores
{
    public class UserStore
    {
        public event Action<User> UserCreated;
        private string pathFile = @"E:\the-hangman-game\the-hangman-game.NET\TheHangmanGame\Services\Users.txt";

        public UserStore() { }

        public void UpdateAvatarProfile(User user, ImgPath newImagePath)
        {
            //if(SearchUser(user) is User)
            //{
            //}
            Console.WriteLine("NOT IMPLEMENTED YEAT");
            //string[] temp;
            //temp = System.IO.File.ReadAllLines(@pathFile);
            //string searchedUser = user.username + " " + user.password + " " + user.avatarPath;
            //Console.WriteLine(user.username + " " + user.password + " " + user.avatarPath.ToString());
            //string modifiedUserWithNewImage = user.username + " " + user.password + " " + newImagePath;
            //Console.WriteLine(searchedUser + "\n" + modifiedUserWithNewImage);           
            //temp.(searchedUser, modifiedUserWithNewImage); 
            //File.WriteAllText(@pathFile, temp); 
        }
        public void CreateUser(User user)
        {
            try
            {
                if (!(SearchUser(user) is User))
                {
                    UserCreated?.Invoke(user);
                    using (StreamWriter writer = File.AppendText(pathFile))
                    {
                        var uri = new Uri(@"#", UriKind.Relative);
                        ImgPath path = new BitmapImage(uri);
                        writer.WriteLine(user.username + " " + user.password + " " + path);
                        Console.WriteLine("Successfully new user created");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public User SearchUser(User searchedUser)
        {
            // Console.Write("DA FRATE SUNT AICI");
            string[] temp;
            List<Tuple<string, string, ImgPath>> playersFromFile = new List<Tuple<string, string, ImgPath>>();
            temp = System.IO.File.ReadAllLines(@pathFile);
            foreach (string it in temp)
            {
                string[] userAndPassword = it.Split(' ');
                if (userAndPassword[0] == searchedUser.username && userAndPassword[1] == searchedUser.password)
                {
                    int imageNr = -1;
                    foreach (char c in userAndPassword[2])
                    {
                        if (c - '0' >= 1 && c - '0' <= 9)
                        {
                            imageNr = c - '0';
                            break;
                        }
                    }
                    if (imageNr != -1)
                    {
                        ImgPath path = new BitmapImage(new Uri(@"/Imagez/NewFolder/" + imageNr + ".jpg", UriKind.Relative));
                        User userIdk = new User(userAndPassword[0], userAndPassword[1], path);
                        return userIdk;
                    }
                    else
                    {
                        ImgPath path = new BitmapImage(new Uri(@"#", UriKind.Relative));
                        User userIdk = new User(userAndPassword[0], userAndPassword[1], path);
                        return userIdk;
                    }
                }

            }
            return null;
        }
    }
}
