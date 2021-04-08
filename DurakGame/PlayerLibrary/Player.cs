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
        public string PlayerName { get; set; }          // The name of the player
        public Cards PlayerHand { get; set; }           // A list of cards, that is the players hand
        public int PlayerCardCount { get; set; }        // The number of cards currently in the players hand.
        public bool PlayerIsAttacking { get; set; }     // A boolean to demonstrate if a player is attacking or defending


        // Constructors
        /// <summary>
        /// Player(String, Bool) - The constructor for the player class. Each player can be given a name, and an 
        ///            isAttacking boolean value. By default each player is named "Player" and set to
        ///            set as defending (false). Player objects are given an empty hand and given a value
        ///            of 0 for the number of cards in hand.
        /// </summary>
        /// <param name="PlayerName">The name of the Player.</param>
        /// <param name="isAttacking">A true/false showing if a player is attacking or defending.</param>
        public Player(string PlayerName = "Player", bool isAttacking = false)
        {
            this.PlayerName = PlayerName;
            this.PlayerHand = new Cards();
            this.PlayerCardCount = 0;
            this.PlayerIsAttacking = isAttacking;
        }

        /// <summary>
        /// DrawCard(Card) - This method is used to add a Card object to the the Players hand.
        ///                It will also increment the PlayerCardCount value by 1.
        /// </summary>
        /// <param name="card">A Card object to be added to the players hand.</param>
        public void DrawCard(Card card)
        {
            this.PlayerHand.Add(card);
            PlayerCardCount++;
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
            for (int i = this.PlayerCardCount; i < handBaseLine; i++)
            {
                // Draw a card off the top of the deck, into the hand
                if (playingDeck.HasCards())
                    this.DrawCard(playingDeck.DrawNextCard());
            }
        }

        /// <summary>
        /// PlayCard(int) - This method is used to Play a card from the Players hand.
        ///               An integer is passed to the method to indicate the index to
        ///               draw from. The card is removed from the players hand and returned 
        ///               by the method.
        /// </summary>
        /// <param name="handIndex">The Index of the PlayerHand to draw from</param>
        /// <returns>A Card object</returns>
        public Card PlayCard(int handIndex)
        {
            //TODO: Exception handling for Out of Bounds index. (less than 0 and greater than PlayerCardCount)
            //This might be best done in the GetCard method below this one (aka check before playing).

            // Retrieve the card from the players hand
            Card chosenCard = GetCard(handIndex);

            // Remove the card from the players hand
            PlayerHand.RemoveAt(handIndex);
            PlayerCardCount--;



            return chosenCard;
        }

        /// <summary>
        /// GetCard(int) - This method is used to retrieve a card from the Players hand.
        ///              An integer is passed to the method to indicate the index to
        ///              retrieve. The card is retrieved (Not removed) from the players hand 
        ///              and returned by the method.
        /// </summary>
        /// <param name="handIndex">The Index of the PlayerHand to draw from</param>
        /// <returns>A Card object</returns>
        public Card GetCard(int handIndex)
        {
            return this.PlayerHand[handIndex];
        }

    }
}
