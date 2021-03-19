using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLibrary;
using PlayerLibrary;

namespace DurakGame
{
    class DurakGame
    {
        private static Card trumpCard;
        public static Card TrumpCard
        {
            get { return trumpCard; }
            set
            {
                trumpCard = value;
                Card.TrumpSuit = value.Suit;

            }
        }

        public static Card AttackCard { get; set; }
        public static Card defendCard { get; set; }
        public static Deck GameDeck { get; set; }
        public static Player[] Players { get; set; }


        public static void StartGame()
        {
            // Reset all Game Logic and Rules for a new Game
            ResetGameVariables();

            // Display the trump suit
            Console.WriteLine("Trump Suit: {0}", DurakGame.TrumpCard.Suit);


            do
            {
                GameRound();
                // Play the game until there are no cards left in the deck
            } while (GameDeck.HasCards());

        }


        public static void GameRound()
        {
            int cardCount;
            Card[] playedCards = new Card[2];
            int cardCounter = 0;

            // Display player info, cards in hand and allow player to play a card
            foreach (Player player in Players)
            {

                Console.WriteLine("{0}'s Hand:", player.PlayerName);
                cardCount = 1;

                //display player hand
                foreach (Card card in player.PlayerHand)
                {
                    card.FaceUp = true;
                    Console.WriteLine("Card {0}: {1}", cardCount, card.ToString());
                    cardCount++;
                }



                // Game logic function, soon to be converted to a class
                gameLogic(cardCounter, player, ref playedCards);
                cardCounter++;
            }


            // Display cards both players have played
            cardCounter = 0;
            foreach (Player player in Players)
            {
                Console.WriteLine("{0} played: {1}\n", player.PlayerName, playedCards[cardCounter]);
                cardCounter++;
            }

            FillPlayerHands(Players);

        }


        public static void ResetGameVariables()
        {
            // Create the Players
            Players = new Player[2];
            Players[0] = new Player("Calvin", true);
            Players[1] = new Player("Tom");

            Players[0].PlayerIsAttacking = true;

            // Create and shuffle a deck
            GameDeck = new Deck(36);
            GameDeck.Shuffle();

            // Set the trump card
            TrumpCard = GameDeck.DrawNextCard();

            // Fill the players hand for the start of the match
            FillPlayerHands(Players);

            // Set the Attcking Player


        }



        public static void FillPlayerHands(Player[] players)
        {
            foreach (Player player in players)
            {
                player.FillHand(GameDeck);
            }
;        }

        static int checkInput(Player player)
        {

            int userInput; // An int for holding user input

            // Prompt the player to play a card
            Console.Write("Play a card(use Index value):");
            if (!int.TryParse(Console.ReadLine(), out userInput))
                return checkInput(player);

            // If the Player is Attacking.
            if (player.PlayerIsAttacking)
            {
                // Store the played Card as the Attack Card.
                AttackCard = player.GetCard(userInput - 1);

            }
            // If the Player is Defending
            else
            {
                // Check to see if the Defending Player is playing an illegal suit
                if (player.GetCard(userInput - 1).Suit != AttackCard.Suit && player.GetCard(userInput - 1).Suit != TrumpCard.Suit)
                {
                    // Write an error message regarding the Cards suit
                    Console.WriteLine("{0} is not the correct suit, you must play {1} suit", player.GetCard(userInput - 1), AttackCard.Suit);
                    // Use Recursion to prompt for input once more
                    return checkInput(player);
                }
                // If the Card is of the correct suit, Check if the card is equal or lower in value
                else if (player.GetCard(userInput - 1) <= AttackCard)
                {
                    // Write an error message regarding the Cards rank
                    Console.WriteLine("{0} is no strong enough, please play a card higher then {1}", player.GetCard(userInput - 1), AttackCard);
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


    }
}
