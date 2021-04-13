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
        /// <summary>
        /// Find the index of the lowest card that can be used to attack
        /// </summary>
        /// <returns>Lowest card value index for attacking card</returns>
        public int GetAttackingCardIndex()
        {
            return GetLowestCardIndex();
        }

        /// <summary>
        /// Find the index of the lowest card that can be used to defend
        /// </summary>
        /// <param name="attackingCard"></param>
        /// <returns></returns>
        public int GetDefendingCardIndex(Card attackingCard)
        {

            return GetLowestCardIndex(attackingCard as Object);
        }

        //find the lowest card, attacking or defending
        private int GetLowestCardIndex(Object obj = null)
        {
            //sort AI hand to get lowest card order
            this.PlayerHand.Sort();
            //return 0 to skip turn
            int cardIndex = 0;
            //reset list
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
                        //check each card that has been played and see what cards can be played
                        for (int i = 1; i <= this.PlayerCardCount; i++)
                        {
                            if (PlayerHand[i - 1].Rank == card.Rank)
                            {
                                
                                playableCards.Add(i-1);
                            }
                        }
                    }

                    //if there are multiple cards that can be played
                    if (playableCards.Count() >= 2)
                    {
                        // check to see which card is the lowest and insert the index of that card to the return variable
                        for (int i = 0; i < playableCards.Count() - 1; i++)
                        {
                            //if the card is not the last card in the playable cards list
                            if (i != playableCards.Count() - 1)
                            {
                                //compare current card with the next card
                                if (PlayerHand[playableCards[i]] < PlayerHand[playableCards[i + 1]])
                                {
                                    //add one to index because game logic subtracts one
                                    cardIndex = playableCards[i] + 1;
                                }
                                else
                                {
                                    cardIndex = playableCards[i + 1] + 1;

                                }
                            }

                            
                        }
                    }
                    //if there is only one playable card select that index + 1
                    else if (playableCards.Count() == 1)
                    {
                        cardIndex = playableCards[0] + 1;
                    }

                }
                //if it is the first attack round chose lowest card
                else
                {
                    //find lowest card that isnt a trump card in player hand
                    for (int i = 1; i < this.PlayerCardCount + 1; i++)
                    {
                        if (PlayerHand[i - 1].Suit != DurakGame.DurakConsole.TrumpCard.Suit)
                        {
                            cardIndex = i;
                            break;
                        }
                    }

                    //if no card was selected chose lowest trump card
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
            //AI is defending
            else
            {
                Card attackingCard = obj as Card;

                //find a card that matches the suit of the played card and is stronger
                for (int i = 1; i < this.PlayerCardCount + 1; i++)
                {

                    if (PlayerHand[i - 1].Suit == attackingCard.Suit && PlayerHand[i - 1] > attackingCard)
                    {
                        cardIndex = i;
                        break;
                    }
                }

                //if no card was selected, find a trump card that is stronger
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
