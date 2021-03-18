/* Deck.cs - This file contains the Deck class. The Deck class is a container
 *         class which will contain a 52 standard deck of cards.
 * 
 * Author(s): Beginning C# 7 Programming with Visual Studio 2017
 *            Calvin May
 *            
 * Date: 1/24/2021 | Last-Modified: 03/09/2021
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
        // A Delegate for the LastCardDrawn Event
        public event EventHandler LastCardDrawn;

        // The list of cards in the deck
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

        // parameterized Constructor
        public Deck(int size)
        {
            // Line of code removed here
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    if (size == 36 && (rankVal < 2 || rankVal > 5))
                        cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                    else if (size == 20 && (rankVal < 2 || rankVal > 9))
                        cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                   else
                       cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }
        }

        public bool HasCards()
        {
            if (this.cards.Count() > 0)
                return true;

            return false;

        }

        public Card GetCard(int cardNum)
        {
            // Check if the index being retrieved is within bounds
            if (cardNum >= 0 && cardNum <= (cards.Count() - 1))
            {
                // If the retrieved index is the last card, and a LastCardDraw Event has been wired
                if ((cardNum == (cards.Count() - 1)) && (LastCardDrawn != null))
                    // Call the Event
                    LastCardDrawn(this, EventArgs.Empty);

                // Regardless, return the card.
                return cards[cardNum];
            }
            // If not,
            else
                // Throw a CardOutOfRangeException Exception
                throw new CardOutOfRangeException((Cards)cards.Clone());
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