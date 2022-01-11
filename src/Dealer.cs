using System;
using System.Collections.Generic;
using System.Text;

/*
 
    Class for the dealer. This class contains the list with the deck. 
    Manages dealing the cards and removing them from the deck so that the
    game remains fair.

 */

namespace Blackjack
{
    class Dealer
    {
        private List<string> Deck = new List<string>()
        {
            "King","King","King","King",
            "Queen","Queen","Queen","Queen",
            "Jack","Jack","Jack","Jack",
            "10","10","10","10",
            "9","9","9","9",
            "8","8","8","8",
            "7","7","7","7",
            "6","6","6","6",
            "5","5","5","5",
            "4","4","4","4",
            "3","3","3","3",
            "2","2","2","2",
            "Ace","Ace","Ace","Ace"
        };
        private bool dealt_;
        public bool Dealt => dealt_;

        public Random rand = new Random();

        public Dealer() {}

        public void InitialDeal(Hand hand) 
        {
            for (int i = 0; i <= 1; i++) 
            {
                int x = rand.Next(Deck.Count);
                hand.AddCard(Deck[x]);
                Deck.RemoveAt(x);
            }
            dealt_ = true;
        }

        public void Hit(Hand hand) 
        {
            int x = rand.Next(Deck.Count);
            hand.AddCard(Deck[x]);
            Deck.RemoveAt(x);
        }

        public void HitDealer(Hand hand) 
        {
            int x = rand.Next(Deck.Count);
            hand.AddDealerCard(Deck[x]);
            Deck.RemoveAt(x);
        }

        public bool Busted(Hand hand) 
        {
            if (hand.getTotal() > 21)
                return true;
            else
                return false;
        }

    }
}
