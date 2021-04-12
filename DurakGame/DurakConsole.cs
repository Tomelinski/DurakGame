using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLibrary;
using PlayerLibrary;

namespace DurakGame
{
    class DurakConsole
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
        public static Card DefendCard { get; set; }
        public static Cards PlayedCards;
        //public static Cards AllPlayedCards;
        public static Deck GameDeck { get; set; }
        public static Player[] Players { get; set; }
        private static int AttackingPlayer { get; set; }
        private static bool RoundOver { get; set; }
        private static bool DefendingPlayerSkip { get; set; }

        public static void RotateAttacker()
        {
            Players[AttackingPlayer].PlayerIsAttacking = false;

            if (AttackingPlayer == Players.Count() - 1)
            {
                AttackingPlayer = 0;
            }
            else
            {
                AttackingPlayer++;
            }

            Players[AttackingPlayer].PlayerIsAttacking = true;

        }

        public static void StartGame()
        {
            // Reset all Game Logic and Rules for a new Game
            ResetGameVariables();
            PlayedCards = new Cards();
            bool lastRound = false;
            bool noCardsInHand = false;


            do
            {


                // Display the trump suit
                Console.WriteLine("Trump Suit: {0}\nCards Left: {1}\n", TrumpCard.Suit, GameDeck.CardsRemaining());

                GameRound();

                foreach (Player player in Players)
                {
                    if (player.PlayerHand.Count() == 0)
                        noCardsInHand = true;
                }

                if (!GameDeck.HasCards() && noCardsInHand && RoundOver)
                {
                    lastRound = true;
                }
                
                // Play the game until there are no cards left in the deck
            } while (!lastRound);

            DetermineDurak();

        }


        public static void GameRound()
        {
            RoundOver = false;
            DefendingPlayerSkip = false;
            int cardCount;

            // Display player info, cards in hand and allow player to play a card
            foreach (Player player in Players)
            {
                player.PlayerHand.Sort();
                Console.WriteLine("{0} is {1}\n", player.PlayerName, (player.PlayerIsAttacking ? "Attacking" : "Defending"));
                cardCount = 1;

                //display player hand
                foreach (Card card in player.PlayerHand)
                {
                    card.FaceUp = true;
                    Console.WriteLine("Card {0}: {1}", cardCount, card.ToString());
                    cardCount++;
                }


                // Game logic function, soon to be converted to a class
                gameLogic(player);

                if (RoundOver)
                    break;

            }


            // Display cards both players have played
            //cardCounter = 0;

            if (!RoundOver)
            foreach (Player player in Players)
            {
                if (player.PlayerIsAttacking)
                {
                    Console.WriteLine("{0} attacked with: {1}\n", player.PlayerName, AttackCard);
                }
                else
                {
                    Console.WriteLine("{0} defending with: {1}\n", player.PlayerName, DefendCard);
                }
                //cardCounter++;
            }
            else
            {

                FillPlayerHands(Players);
                if (!DefendingPlayerSkip)
                {
                    RotateAttacker();
                    Resort();
                }
            }
        }


        public static void ResetGameVariables()
        {
            // Create the Players
            Players = new Player[2];
            //Players[0] = new Player("Calvin");
            //Players[1] = new Player("Tom");
            Players[0] = new AI("AI1");
            Players[1] = new AI("AI2");



            // Create and shuffle a deck
            GameDeck = new Deck(20);
            GameDeck.Shuffle();

            // Set the trump card
            TrumpCard = GameDeck.DrawNextCard();

            // Fill the players hand for the start of the match
            FillPlayerHands(Players);

            // Set the Attcking Player
            AttackingPlayer = GetInitialAttacker();
            Players[AttackingPlayer].PlayerIsAttacking = true;
            Resort();
            
            RoundOver = false;

        }

        public static void Resort()
        {
            while (!Players[0].PlayerIsAttacking)
            {
                Player tempPlayer = Players[0];

                for (int i = 0; i < Players.Count(); i++)
                {
                    if (i != Players.Count() - 1)
                    {
                        Players[i] = Players[i + 1];
                    }
                    else
                    {
                        Players[i] = tempPlayer;
                    }
                }

            }
            AttackingPlayer = 0;
        }

        public static void FillPlayerHands(Player[] players)
        {
            foreach (Player player in players)
            {
                player.FillHand(GameDeck);
            }
        }

        public static int GetInitialAttacker()
        {
            int playerIndex = 0;    // Default to first Player if anything goes wrong
            Cards lowestCards = new Cards();

            foreach (Player player in Players)
            {
                player.PlayerHand.Sort();
                lowestCards.Add(player.PlayerHand[0]);
            }

            lowestCards.Sort();

            foreach (Player player in Players)
            {
                if (lowestCards[0] == player.PlayerHand[0])
                    playerIndex = Array.IndexOf(Players, player);

            }

            return playerIndex;

        }

        static int checkInput(Player player)
        {
            int userInput = 0; // An int for holding user input

            //Console.WriteLine("Type:"+player.GetType().ToString());
            if (player.GetType().ToString() == "PlayerLibrary.Player")
            {


                // If the Player is Attacking.
                if (player.PlayerIsAttacking)
                {
                    // Prompt the player to play a card
                    Console.Write("Play a card(Press 0 to skip turn):");
                    if (!int.TryParse(Console.ReadLine(), out userInput))
                        return checkInput(player);

                    //check if player input is in bounds
                    if (userInput > player.PlayerHand.Count || userInput < 0)
                    {
                        Console.WriteLine("Card index is out of bounds");
                        return checkInput(player);
                    }

                }
                // If the Player is Defending
                else
                {
                    // Prompt the player to play a card
                    Console.Write("Play a card(Press 0 to skip turn):");
                    if (!int.TryParse(Console.ReadLine(), out userInput))
                        return checkInput(player);

                    //check if player input is in bounds
                    if (userInput > player.PlayerHand.Count || userInput < 0)
                    {
                        Console.WriteLine("Card index is out of bounds");
                        return checkInput(player);
                    }

                    if (userInput != 0)
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
                            Console.WriteLine("{0} vs {1}", DurakConsole.AttackCard, player.GetCard(userInput - 1));

                        }
                    }

                }
            }
            else if (player.GetType().ToString() == "PlayerLibrary.AI")
            {
                Console.WriteLine("AI's turn");
                
                if (player.PlayerIsAttacking)
                {
                    userInput = (player as AI).GetAttackingCardIndex();
                }
                else
                {
                    userInput = (player as AI).GetDefendingCardIndex(AttackCard);
                    
                }
            }
                // Return the user input
                return userInput;
        }

        static public void gameLogic(Player player)
        {
            // Get a card from a player, make sure the card played is valid before playing it
            int playedCard = checkInput(player);

            if (playedCard != 0){
                if (player.PlayerIsAttacking)
                {
                    AttackCard = player.PlayCard(playedCard - 1);
                    Console.WriteLine("Attacking card: " + AttackCard + "\n");
                    PlayedCards.Add(AttackCard);
                }
                else
                {
                    DefendCard = player.PlayCard(playedCard - 1);
                    PlayedCards.Add(DefendCard);

                }
                // This card is a valid play (For attack or Defense) so play it.
                //playedCards[currentPlayer] = DefendCard;
                Console.WriteLine();
            }
            else
            {
                RoundOver = true;
                Console.WriteLine("\n" + player.PlayerName + " has skipped their turn.\n");

                // Check if the skipping player was the defender
                if (!player.PlayerIsAttacking)
                {
                    DefendingPlayerSkip = true;
                    foreach (Card card in PlayedCards)
                    {
                        player.DrawCard(card);

                    }
                }

                PlayedCards = new Cards();

            }
        }

        static public void DetermineDurak()
        {
            if (Players[0].PlayerHand.Count > Players[1].PlayerHand.Count)
                Console.WriteLine("Player: {0} is the Durak!", Players[0].PlayerName);
     
            else
                Console.WriteLine("Player: {0} is the Durak!", Players[1].PlayerName);


            Console.ReadKey();
            
        }


    }
}
