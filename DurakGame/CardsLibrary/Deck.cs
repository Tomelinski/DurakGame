/* Deck.cs - This file contains the Deck class. The Deck class is a container
 *         class which will contain a 52 standard deck of cards.
 * 
 * Author(s): Beginning C# 7 Programming with Visual Studio 2017
 *            Calvin May
 *            
 * Date: 1/24/2021 | Last-Modified: 02/21/2021
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardLibrary
{
    public class Deck : ICloneable // Interface with the ICloneable Interface (Now me must implement the Clone() function)
    {
       
        private Cards cards = new Cards();

        // Default Constructor
        public Deck()
        {
            // Line of code removed here
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }
        }

        // Paramaterized Constructor. Allows aces to be set high.
        public Deck(bool isAceHigh) : this()
        {
            Card.isAceHigh = isAceHigh;
        }

        // Paramaterized Constructor. Allows a trump suit to be used.
        public Deck(bool useTrumps, Suit trump) : this()
        {
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }

        // Paramaterized Constructor. Allows aces to be set high and a trump suit to be used.
        public Deck(bool isAceHigh, bool useTrumps, Suit trump) : this()
        {
            Card.isAceHigh = isAceHigh;
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }

        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
                return cards[cardNum];
            else
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum,
                "Value must be between 0 and 51."));
        }
        public void Shuffle()
        {
            Cards newDeck = new Cards();
            bool[] assigned = new bool[52];
            Random sourceGen = new Random();
            for (int i = 0; i < 52; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(52);
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(cards[sourceCard]);
            }
            newDeck.CopyTo(cards);
        }

        public Card DrawNextCard()
        {
            Card drawnCard;

            drawnCard = this.GetCard(0);
            cards.RemoveAt(0);

            return drawnCard;
        }


        public object Clone()
        {
            // Call the constructor to clone the cards of the Deck object calling this function
            //-Return the clone
            Deck newDeck = new Deck(cards.Clone() as Cards);
            return newDeck;
        }
        // A Private Constructor which takes a Cards Collection as a paramater
        private Deck(Cards newCards)
        {
            // Set the Cards Attribute
            cards = newCards;
        }
    }
}