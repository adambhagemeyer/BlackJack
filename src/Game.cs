using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

/*
 
    Class for running the actual game. 

 */

namespace Blackjack
{
    class Game
    {
        public Game() { }

        public void StartGame() 
        {
            Hand player = new Hand();
            Hand dealer = new Hand();
            Dealer d = new Dealer();

            Console.WriteLine();
            Console.WriteLine("===============================================");
            Console.WriteLine("============ Welcome to blackjack! ============");
            Console.WriteLine("===============================================");
            Console.WriteLine();

            Thread.Sleep(2000);

            d.InitialDeal(player);
            d.InitialDeal(dealer);

            dealer.GetDealerInitial();
            player.GetHand();
            Console.WriteLine();
            Console.WriteLine("Your current total is: " + player.getTotal());
            Console.WriteLine();



            Thread.Sleep(2000);
            bool busted = false;
            while (!busted)
            {
                if (player.getTotal() == 21)
                    break;
                Console.WriteLine("Do you want to hit or stay? (type h for hit and s for stay): ");
                string hit_or_stay = Console.ReadLine();
                if (string.Equals(hit_or_stay, "h"))
                {
                    d.Hit(player);
                    Console.WriteLine();
                    Console.WriteLine("==============================================");
                    Thread.Sleep(1000);
                    Console.WriteLine("==============================================");
                    Thread.Sleep(1000);
                    Console.WriteLine("Last Card: " + player.GetLast());
                    Console.WriteLine("Your new total: " + player.getTotal());
                    Console.WriteLine();
                    if (d.Busted(player))
                        busted = true;
                }
                else if (string.Equals(hit_or_stay, "s"))
                    break;

            }

            Console.WriteLine();
            Console.WriteLine("==============================================");
            Thread.Sleep(1000);
            Console.WriteLine("==============================================");
            Thread.Sleep(1000);
            Console.WriteLine("==============================================");
            Thread.Sleep(1000);
            Console.WriteLine();

            if (!busted)
            {
                bool dealer_wins = false;
                bool dealer_loses = false;
                dealer.GetDealerHand();

                while (!dealer_wins && !dealer_loses)
                {
                    if (d.Busted(dealer))
                        dealer_loses = true;
                    else if (dealer.getTotal() >= player.getTotal())
                        dealer_wins = true;
                    else if (dealer.getTotal() < player.getTotal())
                        d.HitDealer(dealer);
                }

                Console.WriteLine();
                Console.WriteLine("==============================================");
                Thread.Sleep(1000);
                Console.WriteLine("==============================================");
                Thread.Sleep(1000);
                Console.WriteLine("==============================================");
                Thread.Sleep(1000);
                Console.WriteLine();

                if (dealer_wins)
                {
                    dealer.GetDealerHand();
                    Console.WriteLine("You lose!");
                }
                if (dealer_loses)
                {
                    dealer.GetDealerHand();
                    Console.WriteLine("You Win!");
                }
            }

            else
                Console.WriteLine("You busted!");

            Console.WriteLine();
            Console.WriteLine("==============================================");
            Thread.Sleep(1000);
            Console.WriteLine("==============================================");
            Thread.Sleep(1000);
            Console.WriteLine();

            Console.Write("Do you want to play again? (type y for yes or n for no): ");
            string new_game = Console.ReadLine();

            if (string.Equals(new_game, "y"))
                StartGame();
            else
            {
                Console.WriteLine("Thank you for playing, goodbye!");
                Console.WriteLine();
                Console.WriteLine("==============================================");
                Thread.Sleep(1000);
                System.Environment.Exit(0);
            }
        }

        
    }
}
