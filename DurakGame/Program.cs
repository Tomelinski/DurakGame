/* Program.cs - 
 *         
 * Author(s): Aadithkeshev Anushayamunaithuraivan,
 *            Menushan Karunakaran,
 *            Calvin May,
 *            Tom Zielinski
 *            
 * Date: 02/27/2021
 */

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

        static public void gameLogic()
        {

        }

        static void Main(string[] args)
        {
            // Create the Player and Deck, Shuffle the Deck to get different Cards
            Player[] players = { new Player("Calvin", true), new Player("Tom") };

            //get the trump suit from a new deck
            Deck gameDeck = new Deck();
            gameDeck.Shuffle();

            Card trumpSuit = gameDeck.DrawNextCard();

            //create a new deck with a trump suit
            gameDeck = new Deck(true, trumpSuit.suit);
            //gameDeck.GetCard();
            gameDeck.Shuffle();

            //fill each players hand
            foreach (Player player in players)
            {
                player.FillHand(gameDeck);
            }
            int count = 1;
            int counter = 0;
            do
            {
                //display the trump suit
                Console.WriteLine("Trump Suit: {0}", trumpSuit.suit);

                //reset counter 
                int cardCounter = 0;
                //reset played cards after each turn
                Card[] playedCards = new Card[2];
                counter++;
                //display player info, cards in hand and allow player to play a card
                foreach (Player player in players)
                {
                    count = 1;
                    Console.WriteLine("{0}'s Hand:", player.Name);
                    //display player hand
                    foreach (Card card in player.Hand)
                    {
                        Console.WriteLine("Card {0}: {1}", count, card.ToString());
                        count++;
                    }

                    //prompt player to play a card
                    Console.Write("Play a card(use Index value):");
                    int playedCard = int.Parse(Console.ReadLine());
                    playedCards[cardCounter] = player.PlayCard(playedCard-1);
                    cardCounter++;
                    Console.WriteLine();

                    //game logic function, soon to be converted to a class
                    gameLogic();
                }

                //display cards both players have played
                cardCounter = 0;
                foreach (Player player in players)
                {
                    Console.WriteLine("{0} played: {1}\n", player.Name, playedCards[cardCounter]);
                    cardCounter++;
                }

                //after each turn fill each players hand
                foreach (Player player in players)
                {
                    player.FillHand(gameDeck);
                }
                //play the game until there are no cards left in the deck
            } while (gameDeck.hasCards() && (players[0].CardCount != 0 || players[1].CardCount != 0));

            /*
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
            */

/*
            Deck testDeckTwo = new Deck();

            Card outofRangeCard = testDeckTwo.GetCard(35);
            Console.WriteLine("Card: {0}", outofRangeCard);

            Card newCardTwo = testDeckTwo.DrawNextCard();
            outofRangeCard = testDeckTwo.GetCard(34);
            Console.WriteLine("\nCard: {0}", outofRangeCard);
*/

            Console.ReadKey();
        }
    }
}
