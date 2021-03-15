/* AI.cs - This file contains the AI class. The AI class is a class representing
 *           a AI in a Card game. The AI will inherit from the Player Class
 *         
 * Author(s): Aadithkeshev Anushayamunaithuraivan,
 *            Menushan Karunakaran,
 *            Calvin May,
 *            Tom Zielinski
 *            
 * Date: 2021-03-13
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLibrary;  // Make use of the CardLibrary

namespace PlayerLibrary
{
    public class AI : Player
    {
        private readonly static int handBaseLine = 6;   // Represents the number of cards that should be in a AI hand at the start of each round

        // Private Datamembers
        private string AIName;          // The name of the AI
        private Cards AIHand;           // A list of cards, that is the AI hand
        private int AICardCount;        // The number of cards currently in the AI hand.
        private bool AIIsAttacking;     // A boolean to demonstrate if a AI is attacking or defending

        // Default Constructor
        public AI() { }


        // to be cont'd
        public AI(Player AiHand)
        {

        }

        // Getters & Setters

        public Cards AIHandSet  // Public Property for Getting/Setting the AI Hand
        {
            get // Accessing
            {
                return AIHand;
            }
            set // Mutating
            {
                AIHand = value;
            }
        }

        public int AICardCountSet  // Public Property for Getting/Setting the number of cards in a AI hand
        {
            get // Accessing
            {
                return AICardCount;
            }
        }

        public bool AIIsAttackingSet  // Public Property for Getting/Setting the attack/defense boolean
        {
            get // Accessing
            {
                return AIIsAttacking;
            }
            set // Mutating
            {
                AIIsAttacking = value;
            }
        }

        // Remove Card
        public void AIRemoveCard(Card card)
        {
            AIHand.Remove(card);
        }

        // Draw Card
        public void AIDrawCard(Card card)
        {
            this.AIHand.Add(card);
            AICardCount++;
        }

        // Fill hand
        public new void FillHand(Deck playingDeck)
        {
            // Loop, starting at the number of cards currently in the Hand
            // untill we've reached the number of Cards for a legal hand.
            for (int i = this.AICardCount; i < handBaseLine; i++)
            {
                // Draw a card off the top of the deck, into the hand
                this.DrawCard(playingDeck.DrawNextCard());
            }
        }


        // Attack Phase for AI using CASE/SWITCH
        public void AIAttack(Deck AIattacking)
        {
            Card attack = new Card();

            Cards cloneCards = new Cards();

            bool success = false;
            for(int i = 0; i < handBaseLine; i++)
            {
                cloneCards.Add(AIattacking.GetCard(i));
            }

            switch(handBaseLine)
            {
                case 1:
                    //AI pick Card
                    for(int i = 0; i < ; i++)
                    {

                    }
                    break;
            }
        }



        // Defending Phase for AI using CASE/SWITCH
        public void AIDefend(Deck AIattacking)
        {
            Card attack = new Card();

            Cards cloneCards = new Cards();

            bool success = false;
            for (int i = 0; i < handBaseLine; i++)
            {
                cloneCards.Add(AIattacking.GetCard(i));
            }

            switch (handBaseLine)
            {
                case 1:
                    //AI pick Card
                    for (int i = 0; i < ; i++)
                    {

                    }
                    break;
            }
        }
    }
}
