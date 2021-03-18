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
using DurakGame;
using System.Windows.Forms;

namespace DurakGame
{

    class Program
    {

        static int checkInput(Player player)
        {

            int userInput; // An int for holding user input

            // Prompt the player to play a card
            Console.Write("Play a card(use Index value):");
            if (!int.TryParse(Console.ReadLine(), out userInput))
                return checkInput(player);

            // If the Player is Attacking.
            if (player.IsAttacking)
            {
                // Store the played Card as the Attack Card.
                DurakGame.AttackCard = player.GetCard(userInput - 1);

            }
            // If the Player is Defending
            else
            {
                // Check to see if the Defending Player is playing an illegal suit
                if (player.GetCard(userInput - 1).Suit != DurakGame.AttackCard.Suit && player.GetCard(userInput - 1).Suit != DurakGame.TrumpSuit.Suit)
                {
                    // Write an error message regarding the Cards suit
                    Console.WriteLine("{0} is not the correct suit, you must play {1} suit", player.GetCard(userInput - 1), DurakGame.AttackCard.Suit);
                    // Use Recursion to prompt for input once more
                    return checkInput(player);
                }
                // If the Card is of the correct suit, Check if the card is equal or lower in value
                else if (player.GetCard(userInput - 1) <= DurakGame.AttackCard)
                {
                    // Write an error message regarding the Cards rank
                    Console.WriteLine("{0} is no strong enough, please play a card higher then {1}", player.GetCard(userInput - 1), DurakGame.AttackCard);
                    // Use Recursion to prompt for input once more
                    return checkInput(player);
                }
                // If the Card is both the correct suit and higher value it is a legal play.
                else
                {
                    // Show both the attack and defense card.
                    Console.WriteLine("{0} vs {1}", DurakGame.AttackCard, player.GetCard(userInput - 1));

                }

            }
            // Return the user input
            return userInput;
        }

        static public void gameLogic(int currentPlayer, Player player, ref Card[] playedCards)
        {
            // Get a card from a player, make sure the card played is valid before playing it
            int playedCard = checkInput(player);

            // This card is a valid play (For attack or Defense) so play it.
            playedCards[currentPlayer] = player.PlayCard(playedCard - 1);
            Console.WriteLine();
        }
        [STAThread]
        static void Main(string[] args)
        {
         if(args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.Run(new frmDurakMainMenu());
            }
            Console.WriteLine("Dont read this");
            // Create the Player and Deck, Shuffle the Deck to get different Cards
            Player[] players = { new Player("Calvin", true), new Player("Tom") };

            // Get the trump suit from a new deck
            Deck gameDeck = new Deck();
            gameDeck.Shuffle();

            DurakGame.TrumpSuit = gameDeck.DrawNextCard();

            // Create a new deck with a trump suit
            gameDeck = new Deck(true, DurakGame.TrumpSuit.Suit);
            gameDeck.Shuffle();

            // Fill each players hand
            foreach (Player player in players)
            {
                player.FillHand(gameDeck);
            }
            int count = 1;
            do
            {
                Card[] playedCards = new Card[2];

                // Display the trump suit
                Console.WriteLine("Trump Suit: {0}", DurakGame.TrumpSuit.Suit);

                // Reset counter 
                int cardCounter = 0;
                //reset played cards after each turn
                
                // Display player info, cards in hand and allow player to play a card
                foreach (Player player in players)
                {
                    count = 1;
                    Console.WriteLine("{0}'s Hand:", player.Name);
                    //display player hand
                    foreach (Card card in player.Hand)
                    {
                        card.FaceUp = true;
                        Console.WriteLine("Card {0}: {1}", count, card.ToString());
                        count++;
                    }


                    // Game logic function, soon to be converted to a class
                    gameLogic(cardCounter, player, ref playedCards);
                    cardCounter++;
                }

                
                // Display cards both players have played
                cardCounter = 0;
                foreach (Player player in players)
                {
                    Console.WriteLine("{0} played: {1}\n", player.Name, playedCards[cardCounter]);
                    cardCounter++;
                }
                

                // After each turn fill each players hand
                foreach (Player player in players)
                {
                    player.FillHand(gameDeck);
                }
                // Play the game until there are no cards left in the deck
            } while (gameDeck.HasCards() && (players[0].CardCount != 0 || players[1].CardCount != 0));

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
