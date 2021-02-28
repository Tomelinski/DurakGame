using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLibrary;
using PlayerLibrary;

namespace DurakGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the Player and Deck, Shuffle the Deck to get different Cards
            Player testPlayer = new Player("Calvin", false);
            Deck testDeck = new Deck();
            testDeck.Shuffle();

            testPlayer.FillHand(testDeck);
            int count = 1;

            //////////////////////////////////////////////////////
            // Display the Hand
            Console.WriteLine("Test Players Hand After Creating a Deck (Shuffled Too), a Player, and drawing a full hand");
            foreach (Card card in testPlayer.Hand)
            {
                Console.WriteLine("Card {0}: {1}", count, card.ToString());
                count++;
            }
            Console.WriteLine("\nNumber of Cards in Hand: {0}", testPlayer.CardCount);

            //////////////////////////////////////////////////////
            // Draw a Card, Redisplay the Hand
            Card playedCard = testPlayer.PlayCard(4);
            count = 1;
            Console.WriteLine("\n\nTest Players Hand After Playing Card 5 ({0})", playedCard.ToString());
            foreach (Card card in testPlayer.Hand)
            {
                Console.WriteLine("Card {0}: {1}", count, card.ToString());
                count++;
            }
            Console.WriteLine("\nNumber of Cards in Hand: {0}", testPlayer.CardCount);


            //////////////////////////////////////////////////////
            // Refill the Hand and Redisplay the Hand
            testPlayer.FillHand(testDeck);
            count = 1;
            Console.WriteLine("\n\nTest Player After Refilling Deck");
            foreach (Card card in testPlayer.Hand)
            {
                Console.WriteLine("Card {0}: {1}", count, card.ToString());
                count++;
            }

            Console.WriteLine("\nNumber of Cards in Hand: {0}", testPlayer.CardCount);

            Console.ReadKey();
        }
    }
}
