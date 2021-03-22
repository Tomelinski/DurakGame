/* Card.cs - This file contains the Card class. Cards will be contained within
 *         a deck class. Each card is given a suit and a rank.
 * 
 * Author(s): Beginning C# 7 Programming with Visual Studio 2017
 *            Calvin May
 *            
 * Date: 1/24/2021 | Last-Modified: 03/09/2021
 * 
 * 
 */

using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/** ATTRIBUTION
 * ==============
 * The card images used in this class were created by David Bellot from SourceForge.
 * They are available for use under a Creative Commons License. Downloaded from:
 * https://sourceforge.net/projects/svg-cards/ 
 *  on 03/12/2021.
 *  
 *  Face down Card image taken from Chris Pelt on Pintrest:
 *  https://www.pinterest.ca/pin/105130972527979556/
 *  
 *  Due to possible copyright concerns this program will be used strictly for
 *  educational purposes and will not be distributed or published.
 */

namespace CardLibrary
{
    public class Card : ICloneable, IComparable // Interface with the ICloneable Interface (Now me must implement the Clone() function)
    {
        // Private Datamembers
        public  Rank Rank { get; set; }           // Represents a Cards Rank   s
        public  Suit Suit { get; set; }           // Represents a Cards Suit
        public bool FaceUp { get; set; } = false; // Indicates if the card is face up or face down

        // Class Data Members
        public static bool UseTrumps { get; set; } = false;      // Flag for trump usage. If true, trumps are valued higher
        public static Suit TrumpSuit { get; set; } = Suit.Clubs; // Trump suit to use if useTrumps is true.
        public static bool IsAceHigh { get; set; } = true;       // Flag that determines whether aces are higher than kings or lower

        // Default constructor
        private Card()
        {

        }

        // Paramaterized Constructor, sets the rank and suit
        public Card(Suit newSuit = Suit.Clubs, Rank newRank = Rank.Ace)
        {
            this.Suit = newSuit;
            this.Rank = newRank;
        }

        // A Comparison Method used to sort Card Instances
        public virtual int CompareTo(Object obj)
        {
            // Check if the Argument is null
            if (obj == null)
            {
                // If so, Throw an Exception
                throw new ArgumentNullException("Error: Unable to compare a card to a null object.");
            }

            // Convert the  argument to a Card Object
            Card compareCard = obj as Card;

            // Check if the Conversion worked
            if (compareCard.GetType() != null)
            {
                // Compare the Card based on Rank and suit
                int thisSort = (int)this.Rank * 10 + (int)this.Suit;
                int compareCardSort = (int)compareCard.Rank * 10 + (int)compareCard.Suit;
                return (thisSort.CompareTo(compareCardSort));
            }
            else
            {
                // Throw an Exception
                throw new ArgumentException("Error: Object being compared cannot be converted to a Card.");
            }
        }

        // An override ToString method to print a card 
        public override string ToString() 
        {
            string cardString;  // Holds the Cards information

            if (FaceUp)
            {
                // Check if the Card is a Joker
                if (this.Rank == Rank.Joker)
                {
                    // Check if the Suit is Dark
                    if (this.Suit == Suit.Clubs || this.Suit == Suit.Spades)
                    {
                        // Set the Card string
                        cardString = "Black Joker";
                    }
                    // Otherwise must be Red
                    else
                    {
                        // Set the Card string
                        cardString = "Red Joker";
                    }
                }
                // If its not a Joker, it can be any other Rank
                else
                {
                    // Set the Card string
                    cardString = this.Rank.ToString() + " of " + this.Suit.ToString();
                }
            }
            // The card is Face down
            else 
            {
                // Set the Card string
                cardString = "Face Down";
            }

            // Return the Card string
            return cardString;
        }
        

        // This is the Clone Method, 
        //-Note that it returns a copy of a Card Object
        public object Clone()
        {
            // Return a Clone of the Card that calls this function (This is a shallow Copy)
            return MemberwiseClone();
        }

        // An override ToString method to print a card 
        public Image GetCardImage()
        {
            string imageName;  // Holds the Cards Image Name
            Image cardImage;   // Holds the Cards Image

            if (!FaceUp)
            {
                // Set the Card Image name
                imageName = "Card_Back";
            }
            else
            {
                // Check if the Card is a Joker
                if (this.Rank == Rank.Joker)
                {
                    // Check if the Suit is Dark
                    if (this.Suit == Suit.Clubs || this.Suit == Suit.Spades)
                    {
                        // Set the Card Image name
                        imageName = "Black_Joker";
                    }
                    // Otherwise must be Red
                    else
                    {
                        // Set the Card Image name
                        imageName = "Red_Joker";
                    }
                }
                // If its not a Joker, it can be any other Rank
                else
                {
                    // Set the Card Image name
                    imageName = this.Rank.ToString() + "_of_" + this.Suit.ToString();
                }
            }

            // Set the Card Image
            cardImage = Properties.Resources.ResourceManager.GetObject(imageName) as Image;

            // Return the Card Image name
            return cardImage;
        }

        // Generates a string showing the state of a Card Object
        public string DebugString()
        {
            string cardState = (string)(this.Rank.ToString() + " of " + this.Suit.ToString()).PadLeft(20);
            cardState += (string)((FaceUp) ? "(Face Up)" : "(Face Down)").PadLeft(12);

            return cardState;
        }

        /// <summary>
        /// This is an Overloaded Comparison Operator (==). Allows two cards to be compared to one another by suit and rank.
        /// </summary>
        /// <param name="card1">The first card to compare</param>
        /// <param name="card2">The second card to compare</param>
        /// <returns>True if the cards are equal to one another, false otherwise</returns>
        public static bool operator ==(Card card1, Card card2)
        {
            return (card1.Suit == card2.Suit) && (card1.Rank == card2.Rank);
        }

        /// <summary>
        /// This is an Overloaded Comparison Operator (!=). Checks to see if two cards are not equal to one another.
        /// </summary>
        /// <param name="card1">The first card to compare</param>
        /// <param name="card2">The second card to compare</param>
        /// <returns>False if the cards are equal to one another, True otherwise</returns>
        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }

        /// <summary>
        /// An Override of the built in .Equals() Method. Utilizes the Comparison Operator (==) to check if 
        /// two cards are the same.
        /// </summary>
        /// <param name="card">The card to compare to</param>
        /// <returns>True if the cards are equal to one another, false otherwise</returns>
        public override bool Equals(object card)
        {
            return this == (Card)card;
        }

        /// <summary>
        /// An Override of the built in .GetHashCode() Method. Generates a predictable Hashcode for each
        /// possible card variation.
        /// </summary>
        /// <returns>An integer that identifies a particular card</returns>
        public override int GetHashCode()
        {
            return 13 * (int)Suit + (int)Rank;
        }

        /// <summary>
        /// An Overloaded Comparison Operator (>). Checks to see if the first card is greater than the second card.
        /// </summary>
        /// <param name="card1">The first card to compare</param>
        /// <param name="card2">The second card to compare</param>
        /// <returns>True if card 1 is greater than card 2, false otherwise</returns>
        public static bool operator >(Card card1, Card card2)
        {
            // First check to see if both cards are of the same suit
            if (card1.Suit == card2.Suit)
            {
                // Check if Aces are considered High
                if (IsAceHigh) // If so, 
                {
                    // Check if card 1 is an Ace
                    if (card1.Rank == Rank.Ace)
                    {
                        // If it is, card 1 wins so return true; 
                        //-otherwise return false
                        if (card2.Rank == Rank.Ace)
                            return false;
                        else
                            return true;
                    }
                    // If card1 is not an ace, check to see if card2 is an ace
                    else
                    {
                        // If it is, card 2 wins so return false; 
                        //-otherwise check which rank is highest and return true
                        //-if card1 is higher, false otherwise.
                        if (card2.Rank == Rank.Ace)
                            return false;
                        else
                            return (card1.Rank > card2.Rank);
                    }
                }
                // Ace is not considered high, return true if card 1s rank is greater, false otherwise.
                else
                {
                    return (card1.Rank > card2.Rank);
                }
            }
            // If they are not of the same suit
            else
            {
                // Check if trump cards are enabled and if card2 is of the trump suit.
                if (UseTrumps && (card2.Suit == Card.TrumpSuit))
                    return false;   // return false, because Trump suit beats
                else
                    return true;    // return true because card2 is not the correct suit
            }
        }

        /// <summary>
        /// An Overloaded Comparison Operator (<). Checks to see if the first card is less than the second card.
        /// </summary>
        /// <param name="card1">The first card to compare</param>
        /// <param name="card2">The second card to compare</param>
        /// <returns>True if card 1 is less than card 2, false otherwise</returns>
        public static bool operator <(Card card1, Card card2)
        {
            // Call the >= operator, but check for reverse values.
            return !(card1 >= card2);
        }

        /// <summary>
        /// An Overloaded Comparison Operator (>=). Checks to see if the first card is greater or equal to the second card.
        /// </summary>
        /// <param name="card1">The first card to compare</param>
        /// <param name="card2">The second card to compare</param>
        /// <returns>True if card 1 is greater than or equal to card 2, false otherwise</returns>
        public static bool operator >=(Card card1, Card card2)
        {
            // First check to see if both cards are of the same suit
            if (card1.Suit == card2.Suit)
            {
                // Check if Aces are considered High
                if (IsAceHigh)
                {
                    // Check if card 1 is an Ace
                    if (card1.Rank == Rank.Ace)
                    {
                        return true;
                    }
                    // If card1 is not an Ace
                    else
                    {
                        // Check if card 2 is an Ace
                        if (card2.Rank == Rank.Ace)
                            return false;
                        // Otherwise compare their ranks, returning true if card1s rank is greater or equal to card2s rank
                        else
                            return (card1.Rank >= card2.Rank);
                    }
                }
                // Ace is not considered high, return true if card 1s rank is greater or equal, false otherwise.
                else
                {
                    return (card1.Rank >= card2.Rank);
                }
            }
            // If they are not of the same suit
            else
            {
                // Check if trump cards are enabled and if card2 is of the trump suit.
                if (UseTrumps && (card2.Suit == Card.TrumpSuit))
                    return false; // return false, because Trump suit beats
                else
                    return true; // return true because card2 is not the correct suit
            }
        }

        /// <summary>
        /// An Overloaded Comparison Operator (<=). Checks to see if the first card is lesser or equal to the second card.
        /// </summary>
        /// <param name="card1">The first card to compare</param>
        /// <param name="card2">The second card to compare</param>
        /// <returns>True if card 1 is less than or equal to card 2, false otherwise</returns>
        public static bool operator <=(Card card1, Card card2)
        {
            // Call the > operator, but check for reverse values.
            return !(card1 > card2);
        }

    }
}