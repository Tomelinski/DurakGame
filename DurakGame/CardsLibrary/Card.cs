/* Card.cs - This file contains the Card class. Cards will be contained within
 *         a deck class. Each card is given a suit and a rank.
 * 
 * Author(s): Aadithkeshev Anushayamunaithuraivan,
 *            Menushan Karunakaran,
 *            Calvin May,
 *            Tom Zielinski
 *            
 * Date: 02/25/2021
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardLibrary
{
    public class Card : ICloneable // Interface with the ICloneable Interface (Now me must implement the Clone() function)
    {
        // Private Datamembers
        public readonly Rank rank; // Represents a Cards Rank
        public readonly Suit suit; // Represents a Cards Suit

        // Class Data Members
        public static bool useTrumps = false; // Flag for trump usage. If true, trumps are valued higher
        public static Suit trump = Suit.Club; // Trump suit to use if useTrumps is true.
        public static bool isAceHigh = true;  // Flag that determines whether aces are higher than kings or lower

        // Default constructor
        public Card()
        {

        }

        // Paramaterized Constructor, sets the rank and suit
        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }

        // An override ToString method to print a card 
        public override string ToString() => "The " + rank + " of " + suit + " ";

        // This is the Clone Method, 
        //-Note that it returns a copy of a Card Object
        public object Clone()
        {
            // Return a Clone of the Card that calls this function (This is a shallow Copy)
            return MemberwiseClone();
        }

        /// <summary>
        /// This is an Overloaded Comparison Operator (==). Allows two cards to be compared to one another by suit and rank.
        /// </summary>
        /// <param name="card1">The first card to compare</param>
        /// <param name="card2">The second card to compare</param>
        /// <returns>True if the cards are equal to one another, false otherwise</returns>
        public static bool operator ==(Card card1, Card card2)
        {
            return (card1.suit == card2.suit) && (card1.rank == card2.rank);
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
            return 13 * (int)suit + (int)rank;
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
            if (card1.suit == card2.suit)
            {
                // Check if Aces are considered High
                if (isAceHigh) // If so, 
                {
                    // Check if card 1 is an Ace
                    if (card1.rank == Rank.Ace)
                    {
                        // If it is, card 1 wins so return true; 
                        //-otherwise return false
                        if (card2.rank == Rank.Ace)
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
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return (card1.rank > card2.rank);
                    }
                }
                // Ace is not considered high, return true if card 1s rank is greater, false otherwise.
                else
                {
                    return (card1.rank > card2.rank);
                }
            }
            // If they are not of the same suit
            else
            {
                // Check if trump cards are enabled and if card2 is of the trump suit.
                if (useTrumps && (card2.suit == Card.trump))
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
            if (card1.suit == card2.suit)
            {
                // Check if Aces are considered High
                if (isAceHigh)
                {
                    // Check if card 1 is an Ace
                    if (card1.rank == Rank.Ace)
                    {
                        return true;
                    }
                    // If card1 is not an Ace
                    else
                    {
                        // Check if card 2 is an Ace
                        if (card2.rank == Rank.Ace)
                            return false;
                        // Otherwise compare their ranks, returning true if card1s rank is greater or equal to card2s rank
                        else
                            return (card1.rank >= card2.rank);
                    }
                }
                // Ace is not considered high, return true if card 1s rank is greater or equal, false otherwise.
                else
                {
                    return (card1.rank >= card2.rank);
                }
            }
            // If they are not of the same suit
            else
            {
                // Check if trump cards are enabled and if card2 is of the trump suit.
                if (useTrumps && (card2.suit == Card.trump))
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