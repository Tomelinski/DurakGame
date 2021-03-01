/* Player.cs - 
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

namespace PlayerLibrary
{
    public class Player
    {
        // Static Datamembers
        private static int handBaseLine = 6;
        // Private Datamembers
        private string playerName;
        private Cards playerHand;
        private int playerCardCount;
        private bool playerIsAttacking;


        // Getters & Setters
        public static int HandBaseLine            // public property linked to the private field 
        {
            get // Accessing
            {
                return HandBaseLine;
            }
        }

        public string Name  // Public Property for Getting/Settingthe Players Name
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

        public Cards Hand  // Public Property for Getting/Settingthe Players Name
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

        public int CardCount  // Public Property for Getting/Settingthe Players Name
        {
            get // Accessing
            {
                return playerCardCount;
            }
        }

        public bool IsAttacking  // Public Property for Getting/Settingthe Players Name
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

        // Constructor
        public Player(string playerName = "Player", bool isAttacking = false)
        {
            this.Name = playerName;
            this.Hand = new Cards();
            this.playerCardCount = 0;
            this.IsAttacking = isAttacking;
        }

        public void DrawCard(Card card)
        {
            this.playerHand.Add(card);
            playerCardCount++;
        }

        public void FillHand(Deck playingDeck)
        {

            for (int i = this.playerCardCount; i < handBaseLine; i++)
            {
                this.DrawCard(playingDeck.DrawNextCard());
            }
        }

        public Card PlayCard(int handIndex)
        {
            //retrieve card from player hand
            Card chosenCard = getCard(handIndex);

            //remove card from player hand
            playerHand.RemoveAt(handIndex);
            playerCardCount--;

            return chosenCard;
        }

        public Card getCard(int handIndex)
        {
            return this.playerHand[handIndex];
        }

    }
}
