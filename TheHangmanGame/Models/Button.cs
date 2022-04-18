using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHangmanGame.Models
{
    public class Button
    {
        public string Letter { get; set; }
        public string Visible { get; set; }

        public Button(string letter, string available)
        {
            Letter = letter;
            Visible = "Visibile";
        }
    }
}
