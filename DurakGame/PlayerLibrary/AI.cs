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
using DurakGame;

namespace PlayerLibrary
{
    public class AI : Player
    {

        public AI() { }

        // Default Constructor
        public AI(string AIName = "AI") : base(AIName)
        {

        }

        public int GetAttackingCardIndex()
        {
            Object nullObj = null;
            return GetLowestCardIndex(nullObj);
        }


        public int GetDefendingCardIndex(Card attackingCard)
        {

            return GetLowestCardIndex(attackingCard as Object);
        }

        private int GetLowestCardIndex(Object obj)
        {
            this.PlayerHand.Sort();
            int cardIndex = -1;

            if (obj == null)
            {
                for (int i = 0; i < this.PlayerCardCount; i++)
                {

                    if (PlayerHand[i].Suit != DurakGame.DurakGame.TrumpCard.Suit)
                    {
                        cardIndex = i;
                        break;
                    }
                }

                if (cardIndex == -1)
                {
                    cardIndex = 0;
                }
            }
            else
            {
                Card attackingCard = obj as Card;

                for (int i = 0; i < this.PlayerCardCount; i++)
                {

                    if (PlayerHand[i].Suit == attackingCard.Suit && PlayerHand[i].Rank >= attackingCard.Rank)
                    {
                        cardIndex = i;
                        break;
                    }
                }

                if (cardIndex == -1)
                {
                    for (int i = 0; i < this.PlayerCardCount; i++)
                    {

                        if (PlayerHand[i].Suit != DurakGame.DurakGame.TrumpCard.Suit && PlayerHand[i] >= attackingCard)
                        {
                            cardIndex = i;
                            break;
                        }
                    }
                    if (cardIndex == -1)
                        cardIndex = 0;
                }
            }  
       

            return cardIndex;
        }

        /// <summary>
        /// Chooses the lowest Card in AI Hand
        /// </summary>
        /// <param name="handIndex"> The number of the actual card </param>

        //public Card chooseCard(Cards handIndex)
        //{
        //    // Initializes the cards
        //    Card chosenCards = this.PlayCard(handIndex);
        //    int numCard = chosenCards.Count;

        //    // Grabs the Lowest Card
        //    Card dropCard = chosenCards[lowestCard(chosenCards)];

        //    chosenCards.Remove(dropCard);

        //    return dropCard;
        //}

        ///// <summary>
        ///// Looks for the lowest card in the given group
        ///// </summary>
        ///// <param name="lCard"> The group which is searched to find the lowest card </param>
        //public int lowestCard(Cards lCard)
        //{
        //    int cardIndex = 0;
        //    for (int i = 0; i < lCard.Count; i++)
        //    {
        //        if (lCard[i] < (lCard[cardIndex]))
        //        {
        //            cardIndex = i;
        //        }
        //    }
        //    return cardIndex;
        //}
    }
}
