using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHangmanGame.Models
{
    public class DataProvider
    {
        static public string GetWordToGuess(ECategory category)
        {
            string pathFile = @"E:\the-hangman-game\the-hangman-game.NET\TheHangmanGame\Services\Users.txt";
            switch (category)
            {
                case ECategory.eCars:
                    pathFile = @"E:\the-hangman-game\the-hangman-game.NET\TheHangmanGame\Services\Cars.txt";
                    break;
                case ECategory.eMovies:
                    pathFile = @"E:\the-hangman-game\the-hangman-game.NET\TheHangmanGame\Services\Movies.txt";
                    break;
                case ECategory.eCountries:
                    pathFile = @"E:\the-hangman-game\the-hangman-game.NET\TheHangmanGame\Services\Countries.txt";
                    break;
            }

            string[] strings;
            Random rnd = new Random();
            List<string> words = new List<string>();
            strings = System.IO.File.ReadAllLines(@pathFile);
            for (int i = 0; i < strings.Length; i++)
            {
                words.Add(strings[i]);
            }
            int randomIndex = rnd.Next(1, strings.Length - 1);

            return words[randomIndex];
        }
    }
}
