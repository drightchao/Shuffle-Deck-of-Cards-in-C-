using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            Console.WriteLine("Before Shuffle: ");
            myDeck.showCards();
            Console.WriteLine("*****************");
            Console.ReadKey();
            myDeck.shuffle();
            Console.WriteLine("After Shuffle: ");
            myDeck.showCards();
            Console.ReadKey();
        }
    }

    internal class Card
    {
        private string suit;
        private string rank;

        public Card(string s, string r)
        {
            this.suit = s;
            this.rank = r;
        }

        public string Suit
        {
            get { return suit;  }
            set { suit = value; }
        }

        public string Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        public string description()
        {
            return Rank + " of " + Suit;
        }
    }

    internal class Deck
    {
        private List<Card> deck;
        private string[] ranks = {"ACE", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
        private string[] suits = {"Spade", "Heart", "Club", "Diamond"};

        public Deck()
        {
            this.deck = new List<Card>();
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    deck.Add(new Card(suit, rank));
                }
            }
        }

        public void showCards()
        {
            foreach (var currCard in deck)
            {
                Console.WriteLine(currCard.description());
            }
        }

        public void shuffle()
        {
            List<Card> temp = new List<Card>();
            Random rnd = new Random();
            while (deck.Any())
            {
                int loc = rnd.Next(deck.Count);
                temp.Add(deck.ElementAt(loc));
                deck.RemoveAt(loc);
            }
            deck = temp;
        }
    }
}
