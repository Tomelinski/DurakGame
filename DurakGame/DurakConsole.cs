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

        // Durak Game Static variables
        //-Holds Game Information
        public static Card AttackCard { get; set; }     // Holds the Current Attack Card in the Round
        public static Card DefendCard { get; set; }     // Holds the Current Defend Card in the Round
        public static Cards PlayedCards { get; set; }   // A List of cards currently in play for a Round
        public static Deck GameDeck { get; set; }       // The Deck object being used in this instance
        public static Player[] Players { get; set; }    // An array of Players that are apart of this instance
        private static int AttackingPlayer { get; set; }    // The index of the currnetly attacking Player in the Player array
        private static bool RoundOver { get; set; }         // A boolean to let the program know when a round has ended.
        private static bool DefendingPlayerSkip { get; set; }   // A boolean to let the program know that if a skipping player is a defender.


        /// <summary>
        /// This Method Starts the Game
        /// </summary>
        public static void StartGame()
        {
            // Declarations
            bool gameOver = false;     // A boolean to track if the game is over
            bool noCardsInHand = false; // a boolean to track if a player has played all of their cards.

            // Reset all Game Logic and Rules for a new Game
            ResetGameVariables();


            // While
            do
            {
                // Display the trump suit
                Console.WriteLine("Trump Suit: {0}\nCards Left: {1}\n", TrumpCard.Suit, GameDeck.CardsRemaining());

                // Start a Game round
                GameRound();

                // After each round check if any players have played all of their cards
                foreach (Player player in Players)
                {
                    if (player.PlayerHand.Count() <= 0)
                        noCardsInHand = true;
                }

                // If the Game Deck is out of cards and the one of the Players is out of Cards
                if (!GameDeck.HasCards() && noCardsInHand)
                {
                    gameOver = true;
                }
                
                // Play the game until there are no cards left in the deck
            } while (!gameOver);

            // Check which Player is the Durak
            DetermineDurak();

            // TODO: Allow Players the option of replaying or quiting.

        }


        /// <summary>
        /// This Method Handles each game Round
        /// </summary>
        public static void GameRound()
        {
            RoundOver = false;
            DefendingPlayerSkip = false;
            int cardCount;

            // Display player info, cards in hand and allow player to play a card
            foreach (Player player in Players)
            {
                Console.WriteLine("{0} is {1}\n", player.PlayerName, (player.PlayerIsAttacking ? "Attacking" : "Defending"));
                cardCount = 1;

                //display player hand
                foreach (Card card in player.PlayerHand)
                {
                    card.FaceUp = true;
                    Console.WriteLine("Card {0}: {1}", cardCount, card.ToString());
                    cardCount++;
                }


                // Game logic Method
                gameLogic(player);

                if (RoundOver)
                    break;

            }


            // Display cards both players have played
            //cardCounter = 0;

            if (!RoundOver)
            foreach (Player player in Players)
            {
                // Check if the Player is an Attacking
                if (player.PlayerIsAttacking)
                {
                    Console.WriteLine("{0} attacked with: {1}\n", player.PlayerName, AttackCard);
                }
                // If Defending
                else
                {
                    Console.WriteLine("{0} defending with: {1}\n", player.PlayerName, DefendCard);
                }
                //cardCounter++;
            }
            // If Round is Over
            else
            {
                // Fill Player Hands, Check if the Attacking Player Skipped
                FillPlayerHands(Players);
                if (!DefendingPlayerSkip)
                {
                    // If so Rotate Attacker
                    RotateAttacker();
                    ResortPlayers();
                }
            }
        }


        /// <summary>
        /// ResetGameVariables() - This Method is used to Reset all variables for a Game of Durak.
        /// It Sets up a new Game Deck, Players, and Decides on which Player is the Attacker.
        /// </summary>
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
            ResortPlayers();

            // Reset the PlayedCards List
            PlayedCards = new Cards();

            // Set RoundOver as False
            RoundOver = false;
        }

        /// <summary>
        /// ResortPlayers() - This Method is used to Resort the Players in the Player Array.
        /// This Method ensures that the Attacking Player is always Index 0
        /// </summary>
        public static void ResortPlayers()
        {
            // Loop untill Players[0] is the Attacker
            while (!Players[0].PlayerIsAttacking)
            {
                // Create a Temporary player object to take the place of player [0]
                Player tempPlayer = Players[0];

                // Loop through all the players
                for (int i = 0; i < Players.Count(); i++)
                {
                    // If the Player is not the last, increment
                    if (i != Players.Count() - 1)
                    {
                        Players[i] = Players[i + 1];
                    }
                    // If the Player is the last, set the temporary Player
                    else
                    {
                        Players[i] = tempPlayer;
                    }
                }

            }
            // Set the Attacker to Index 0, ending the loop
            AttackingPlayer = 0;
        }

        /// <summary>
        /// This Method is used to RotateAttackers after each round (When applicable according to Game Logic).
        /// It is used in tandem with ResortPlayers() to maintain proper Attacking Index position
        /// </summary>
        public static void RotateAttacker()
        {
            // Set the current Attacking player to false, no longer attacking
            Players[AttackingPlayer].PlayerIsAttacking = false;

            // If the AttackingPlayer index was the last index in Players array
            if (AttackingPlayer == Players.Count() - 1)
            {
                // Set the attacker to Index 0 (The start of the array)
                AttackingPlayer = 0;
            }
            // If the AttackingPlayer index was NOT the last index in Players array
            else
            {
                // Just increment the AttackingPlayer Index
                AttackingPlayer++;
            }

            // Set the new Attacker using the calculated Index
            Players[AttackingPlayer].PlayerIsAttacking = true;

        }

        /// <summary>
        /// FillPlayerHands(Player[]) - This Method is used to aid in Filling Player Hands after each round.
        /// It simple calls the FillHand Method for all players in the Game
        /// </summary>
        /// <param name="players"></param>
        public static void FillPlayerHands(Player[] players)
        {
            foreach (Player player in players)
            {
                player.FillHand(GameDeck);
                player.PlayerHand.Sort();
            }
        }

        /// <summary>
        /// GetInitialAttacker() - Aids the Program in determining which Player is the Attacker at the
        /// start of a Game. It ensures that the Attacker is the Player with either the lowest trump card
        /// or the lowest general card, if neither players have a trump card.
        /// </summary>
        /// <returns></returns>
        public static int GetInitialAttacker()
        {
            // Default to first Player if anything goes wrong
            int playerIndex = 0;    
            // Temporary Cards List to Hold ALL lowest cards
            Cards lowestCards = new Cards();

            // Get the Lowest card from each player
            foreach (Player player in Players)
            {
                lowestCards.Add(player.PlayerHand[0]);
            }

            // Sort the Cards Provided
            lowestCards.Sort();

            // Find out who the card belonged to
            foreach (Player player in Players)
            {
                if (lowestCards[0] == player.PlayerHand[0])
                    playerIndex = Array.IndexOf(Players, player);

            }

            // Return that Players Index, so we can set them as the attacker
            return playerIndex;

        }

        /// <summary>
        /// checkInput(Player) - One of the Two Main drivers of the Console Application. 
        /// checkInput is responsible for getting valid input from Player characters or
        /// best situational input from Ai characters.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        static int checkInput(Player player)
        {
            int userInput = 0; // An int for holding user input

            // If the Player is an actual Player Character
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

                    // If theres at least 2 cards currently in play...
                    if (PlayedCards.Count() >= 2)
                    {
                        // Check the Validity of the Chosen card against the Played Cards
                        foreach (Card card in PlayedCards)
                        {
                            if (player.GetCard(userInput - 1).Rank != card.Rank)
                            {
                                Console.WriteLine("Card cannot be played");
                                return checkInput(player);
                            }
                        }
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

                    // As long as the User did not select 0 (AKA skip turn)
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
            // If the Player is an AI Character
            else if (player.GetType().ToString() == "PlayerLibrary.AI")
            {
                Console.WriteLine("AI's turn");
                
                // Check for Attack/Defense and Using methods found in the AI class, determine the best 
                //-Card for Play
                if (player.PlayerIsAttacking)
                {
                    userInput = (player as AI).GetAttackingCardIndex(GameDeck, TrumpCard, PlayedCards);
                }
                else
                {
                    userInput = (player as AI).GetDefendingCardIndex(GameDeck, TrumpCard, PlayedCards, AttackCard);
                    
                }
            }
                // Return the user input
                return userInput;
        }

        /// <summary>
        /// gameLogic(Player) - One of the Two Main drivers of the Console Application. 
        /// checkInput is used to recieve Valid input from Player Characters, and best-case-
        /// input from Ai characters. 
        /// Then GameLogic plays the cards against one another and checks if the input indicates
        /// a skip.
        /// </summary>
        /// <param name="player"></param>
        static public void gameLogic(Player player)
        {
            // Get a card from a player, make sure the card played is valid before playing it
            int playedCard = checkInput(player);

            // If the index returned by checkInput IS NOT a skip index(0)
            if (playedCard != 0){
                // Check if the Player is attacking, add the AttackCard if so
                if (player.PlayerIsAttacking)
                {
                    AttackCard = player.PlayCard(playedCard - 1);               // Play the Card
                    Console.WriteLine("Attacking card: " + AttackCard + "\n");  
                    PlayedCards.Add(AttackCard);                                // Add it to PlayedCards
                }
                // Check if the Player is Defending, add the Defending if so
                else
                {
                    DefendCard = player.PlayCard(playedCard - 1);               // Play the Card
                    PlayedCards.Add(DefendCard);                                // Add it to PlayedCards

                }
                // This card is a valid play (For attack or Defense) so play it.
                //playedCards[currentPlayer] = DefendCard;
                Console.WriteLine();
            }
            // If the Returned Index WAS a skip Index (0)
            else
            {
                // End the Round, and indicate that the player has skipped their turn
                RoundOver = true;
                Console.WriteLine("\n" + player.PlayerName + " has skipped their turn.\n");

                // Check if the skipping player was the defender
                if (!player.PlayerIsAttacking)
                {
                    // If so the Defender must pick up all cards currently in Play
                    DefendingPlayerSkip = true;
                    foreach (Card card in PlayedCards)
                    {
                        player.DrawCard(card);

                    }
                }

                // Regardless, Reset the PlayedCards, becasue if the skipping player
                //-was attacking we just discard them anyway
                PlayedCards = new Cards();

            }
        }

        /// <summary>
        /// DetermineDurak() - This Method Quickly determines the Durak by comparing the size of the Playe hands
        /// The player with the most number of cards is the Durak!
        /// </summary>
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
