using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberGuessing UI = new NumberGuessing();
            UI.TitleScreen();
            UI.DifficultySelect();
        }
    }
}
