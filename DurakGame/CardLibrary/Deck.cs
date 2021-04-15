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
using System.Threading.Tasks;

namespace CardLibrary
{
    public class Deck : ICloneable // Interface with the ICloneable Interface (Now me must implement the Clone() function)
    {
        // A Delegate for the LastCardDrawn Event
        public event EventHandler LastCardDrawn;

        // The list of cards in the deck
        private Cards cards = new Cards();
        private Card trumpCard = new Card();

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
                    else if (size == 52)
                    {
                       cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                    }

                }
            }
        }
        
        /// <summary>
        /// Check if deck has more then 1 card 
        /// </summary>
        /// <returns>true if deck.count > 0</returns>
        public bool HasCards()
        {
            if (this.cards.Count() > 0)
                return true;

            return false;

        }

        /// <summary>
        /// returns the amount of cards remaining in the deck
        /// </summary>
        /// <returns></returns>
        public int CardsRemaining()
        {
            return this.cards.Count();
        }

        //get the card baced off the card index from the players hand
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
        /// <summary>
        /// Shuffle the deck of cards with 
        /// </summary>
        public void Shuffle()
        {
            //create a new deck object to store when shuffling deck
            Cards newDeck = new Cards();
            bool[] assigned = new bool[cards.Count];
            Random sourceGen = new Random();
            //loop through to every card in the deck
            for (int i = 0; i < cards.Count; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(cards.Count);
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(cards[sourceCard]);
            }
            newDeck.CopyTo(cards);
        }

        /// <summary>
        /// return the card remove the card at index from players hand
        /// </summary>
        /// <returns>the card that has been removed</returns>
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






        public Card getTrumpCard()
        {
            return trumpCard;
        }

         public void setTrumpCard(Deck deck)
        {
            Card trumpCard;
            trumpCard = deck.DrawNextCard();
            this.trumpCard = trumpCard;
        }
    }
}