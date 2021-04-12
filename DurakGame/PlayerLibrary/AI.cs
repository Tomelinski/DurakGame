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

        // Default Constructor HH
        public AI(string AIName = "AI") : base(AIName)
        {

        }

        public int GetAttackingCardIndex()
        {
            return GetLowestCardIndex();
        }


        public int GetDefendingCardIndex(Card attackingCard)
        {

            return GetLowestCardIndex(attackingCard as Object);
        }

        private int GetLowestCardIndex(Object obj = null)
        {
            //sort AI hand to get lowest card order
            this.PlayerHand.Sort();
            int cardIndex = 0;
            List<int> playableCards = new List<int>();

            //check if attacking card exists this decides if the AI is attacking or defending
            if (obj == null)
            {
                //check if there are cards that have been played
                if (DurakGame.DurakConsole.PlayedCards.Count() >= 2)
                {
                    //compare each card played to the cards that are in hand
                    foreach (Card card in DurakGame.DurakConsole.PlayedCards)
                    {
                        for (int i = 1; i <= this.PlayerCardCount; i++)
                        {
                            if (PlayerHand[i - 1].Rank == card.Rank)
                            {
                                
                                playableCards.Add(i-1);
                            }
                        }
                    }

                    if (playableCards.Count() >= 2)
                    {
                        for (int i = 0; i < playableCards.Count() - 1; i++)
                        {
                            if (i != playableCards.Count() - 1)
                            {
                                if (PlayerHand[playableCards[i]] < PlayerHand[playableCards[i + 1]])
                                {

                                    cardIndex = playableCards[i] + 1;
                                }
                                else
                                {
                                    cardIndex = playableCards[i + 1] + 1;

                                }
                            }

                            
                        }
                    }
                    else if (playableCards.Count() == 1)
                    {
                        cardIndex = playableCards[0] + 1;
                    }

                }
                else
                {
                    for (int i = 1; i < this.PlayerCardCount + 1; i++)
                    {
                        if (PlayerHand[i - 1].Suit != DurakGame.DurakConsole.TrumpCard.Suit)
                        {
                            cardIndex = i;
                            break;
                        }
                    }

                    if (cardIndex == 0)
                    {
                        for (int i = 1; i < this.PlayerCardCount + 1; i++)
                        {
                            if (PlayerHand[i - 1].Suit == DurakGame.DurakConsole.TrumpCard.Suit)
                            {
                                cardIndex = i;
                                break;
                            }
                        }
                    }
                }

            }
            else
            {
                Card attackingCard = obj as Card;

                for (int i = 1; i < this.PlayerCardCount + 1; i++)
                {

                    if (PlayerHand[i - 1].Suit == attackingCard.Suit && PlayerHand[i - 1] > attackingCard)
                    {
                        cardIndex = i;
                        break;
                    }
                }

                if (cardIndex == 0)
                {
                    for (int i = 1; i < this.PlayerCardCount; i++)
                    {

                        if (PlayerHand[i - 1].Suit == DurakGame.DurakConsole.TrumpCard.Suit && PlayerHand[i - 1] > attackingCard)
                        {
                            cardIndex = i;
                            break;
                        }
                    }
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
