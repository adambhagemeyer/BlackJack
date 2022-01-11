using System;
using System.Collections.Generic;
using System.Text;

/*
 
    Class for managing the player and dealer hands.
 
 */

namespace Blackjack
{
    class Hand
    {
        private List<string> hand = new List<string>();
        private int total = 0;

        public int AcesChoice()
        {
            GetHand();
            Console.Write("Do you want to play the ace as a 1 or 11?: ");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a == 1 || a == 11)
                return a;
            else
            {
                Console.WriteLine("Incorrect Entry: Please try again.");
                return AcesChoice();
            }
        
        }

        public void GetDealerInitial()
        {
            Console.WriteLine("Dealer is showing a " + hand[1]);
        }

        public void AddCard(String newCard)
        {
            hand.Add(newCard);
            if (string.Equals(newCard, "King") || string.Equals(newCard, "Queen") || string.Equals(newCard, "Jack"))
            {
                total += 10;
            }
            else if (string.Equals(newCard, "Ace"))
            {
                int s = AcesChoice();
                if (s == 1)
                    total += 1;
                else if (s == 11)
                    total += 11;
            }
            else
                total += Int32.Parse(newCard);
        }

        public void AddDealerCard(String newCard)
        {
            hand.Add(newCard);
            if (string.Equals(newCard, "King") || string.Equals(newCard, "Queen") || string.Equals(newCard, "Jack"))
            {
                total += 10;
            }
            else if (string.Equals(newCard, "Ace"))
            {
                
                if (getTotal() + 11 > 21)
                    total += 1;
                else
                    total += 11;
            }
            else
                total += Int32.Parse(newCard);
        }

        public void GetHand()
        {
            Console.Write("Your hand: ");
            foreach (string x in hand)
                Console.Write(x + " ");
            Console.WriteLine();
        }

        public void GetDealerHand() 
        {
            Console.Write("Dealer Hand: ");
            foreach (string x in hand)
                Console.Write(x + " ");
            Console.WriteLine();
        }

        public string GetLast() 
        {
            return hand[hand.Count - 1];
        }

        public int getTotal() 
        {
            return total;
        }

    }
}
