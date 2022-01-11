using System;
using System.Threading;

/*
 
    Main class for running the entire program
 
 */

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.StartGame();


        }
    }
}
