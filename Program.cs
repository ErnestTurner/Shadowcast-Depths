using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowcastDepths
{
    class Program
    {
        
        static void Main(string[] args)
        {

            
            //The program enters here. The only thing that should happen in here is the creation of a new game object.
            do
            {
                Game g = new Game();
            }
            while (newGame());
        }

        private static bool newGame()
        {
            bool startNewGame = false;
            Console.ReadKey();
            Console.Clear();
            Console.Write("Would you like to start an new life? Y/N ");
            bool valid = false;
            while (!valid)
            {
                char answer;
                answer = Console.ReadKey().KeyChar;
                if (answer == 'y' || answer == 'Y')
                {
                    valid = true;
                    startNewGame = true;
                }
                if (answer == 'n' || answer == 'N')
                {
                    valid = true;
                    
                }
            }
            return startNewGame;
            
        }       

    }
}
