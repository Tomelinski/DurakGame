/* Player.cs - This file contains the Player class. The Player class is a class representing
 *           a player in a Card game. Later, the AiPlayer class will inherit from this class.
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
using CardLibrary;  // Make use of the CardLibrary

namespace PlayerLibrary
{

    public class Player
    {
        // Static Datamembers
        private readonly static int handBaseLine = 6;   // Represents the number of cards that should be in a players hand at the start of each round

        // Private Datamembers
        private string playerName;          // The name of the player
        private Cards playerHand;           // A list of cards, that is the players hand
        private int playerCardCount;        // The number of cards currently in the players hand.
        private bool playerIsAttacking;     // A boolean to demonstrate if a player is attacking or defending


        // Getters & Setters
        public static int HandBaseLine            // Public Property for the handBaseLine Class Variable
        {
            get // Accessing
            {
                return HandBaseLine;
            }
        }

        public string Name  // Public Property for Getting/Setting the Players Name
        {
            get // Accessing
            {
                return playerName;
            }
            set // Mutating
            {
                playerName = value;
            }
        }

        public Cards Hand  // Public Property for Getting/Setting the Players Hand
        {
            get // Accessing
            {
                return playerHand;
            }
            set // Mutating
            {
                playerHand = value;
            }
        }

        public int CardCount  // Public Property for Getting/Setting the number of cards in a players hand
        {
            get // Accessing
            {
                return playerCardCount;
            }
        }

        public bool IsAttacking  // Public Property for Getting/Setting the attack/defense boolean
        {
            get // Accessing
            {
                return playerIsAttacking;
            }
            set // Mutating
            {
                playerIsAttacking = value;
            }
        }

        // Constructors
        /// <summary>
        /// Player(String, Bool) - The constructor for the player class. Each player can be given a name, and an 
        ///            isAttacking boolean value. By default each player is named "Player" and set to
        ///            set as defending (false). Player objects are given an empty hand and given a value
        ///            of 0 for the number of cards in hand.
        /// </summary>
        /// <param name="playerName">The name of the Player.</param>
        /// <param name="isAttacking">A true/false showing if a player is attacking or defending.</param>
        public Player(string playerName = "Player", bool isAttacking = false)
        {
            this.Name = playerName;
            this.Hand = new Cards();
            this.playerCardCount = 0;
            this.IsAttacking = isAttacking;
        }

        /// <summary>
        /// DrawCard(Card) - This method is used to add a Card object to the the Players hand.
        ///                It will also increment the playerCardCount value by 1.
        /// </summary>
        /// <param name="card">A Card object to be added to the players hand.</param>
        public void DrawCard(Card card)
        {
            this.playerHand.Add(card);
            playerCardCount++;
        }

        /// <summary>
        /// FillHand(Deck) - This method is used to draw as many cards as it takes to reach the
        ///                the legal number of cards for a hand (handBaseLine). The deck that is
        ///                passed to this method is the deck whose cards will be drawn from.
        /// </summary>
        /// <param name="playingDeck">A Deck object for drawing cards from.</param>
        public void FillHand(Deck playingDeck)
        {
            // Loop, starting at the number of cards currently in the Hand
            // untill we've reached the number of Cards for a legal hand.
            for (int i = this.playerCardCount; i < handBaseLine; i++)
            {
                // Draw a card off the top of the deck, into the hand
                this.DrawCard(playingDeck.DrawNextCard());
            }
        }

        /// <summary>
        /// PlayCard(int) - This method is used to Play a card from the Players hand.
        ///               An integer is passed to the method to indicate the index to
        ///               draw from. The card is removed from the players hand and returned 
        ///               by the method.
        /// </summary>
        /// <param name="handIndex">The Index of the playerHand to draw from</param>
        /// <returns>A Card object</returns>
        public Card PlayCard(int handIndex)
        {
            //TODO: Exception handling for Out of Bounds index. (less than 0 and greater than playerCardCount)
            //This might be best done in the GetCard method below this one (aka check before playing).

            // Retrieve the card from the players hand
            Card chosenCard = GetCard(handIndex);

            // Remove the card from the players hand
            playerHand.RemoveAt(handIndex);
            playerCardCount--;

            

            return chosenCard;
        }

        /// <summary>
        /// GetCard(int) - This method is used to retrieve a card from the Players hand.
        ///              An integer is passed to the method to indicate the index to
        ///              retrieve. The card is retrieved (Not removed) from the players hand 
        ///              and returned by the method.
        /// </summary>
        /// <param name="handIndex">The Index of the playerHand to draw from</param>
        /// <returns>A Card object</returns>
        public Card GetCard(int handIndex)
        {
            return this.playerHand[handIndex];
        }

    }
}
