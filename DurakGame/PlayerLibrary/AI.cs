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
            List<int> playableCardsIndex = new List<int>();

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
                                //never play the ace of trump suit, unless its the last card
                                if(!(PlayerHand[i - 1].Rank == Rank.Ace && PlayerHand[i - 1].Suit == DurakGame.DurakConsole.TrumpCard.Suit))
                                    playableCardsIndex.Add(i-1);
                                //if its the alst cand in hand, play the ace of trumps
                                else if (PlayerHand.Count() == 1)
                                    playableCardsIndex.Add(i-1);
                            }
                        }
                    }

                    //store the first card that is playable in the index, to compare later
                    if (playableCardsIndex.Count() > 0)
                        cardIndex = playableCardsIndex[0];

                    //if there are multiple cards that can be played
                    if (playableCardsIndex.Count() >= 2)
                    {
                        // check to see which card is the lowest and insert the index of that card to the return variable
                        for (int i = 1; i < playableCardsIndex.Count(); i++)
                        {
                             //play stronger cards if the deck is empty
                             if (!DurakGame.DurakConsole.GameDeck.HasCards())
                             {
                                 //compare current card with the next card
                                 if (!PlayerHand[cardIndex].isStronger(PlayerHand[playableCardsIndex[i]]))
                                 {
                                     //add one to index because game logic subtracts one
                                     cardIndex = playableCardsIndex[i];
                                 }
                             }
                             else
                             {
                                 //compare current card with the next card
                                 if (PlayerHand[cardIndex].isStronger(PlayerHand[playableCardsIndex[i]]))
                                 {
                                     //add one to index because game logic subtracts one
                                     cardIndex = playableCardsIndex[i];
                                 }
                             }
                        
                        }

                        //add 1 to index, gamelogic subtracts one later.
                        cardIndex += 1;
                    }
                    //if there is only one playable card select that index + 1
                    else if (playableCardsIndex.Count() == 1)
                    {
                        //cardIndex = playableCardsIndex[0] + 1;
                        cardIndex += 1;
                    }

                    //return 0 if no cards were selected

                }
                //if it is the first attack round chose lowest card
                else
                {
                    //find lowest card that isnt a trump card in player hand
                    for (int i = 1; i <= this.PlayerCardCount; i++)
                    {
                        if (PlayerHand[i - 1].Suit != DurakGame.DurakConsole.TrumpCard.Suit)
                        {
                            playableCardsIndex.Add(i - 1);
                            //cardIndex = i;
                            //break;
                        }
                    }

                    //******************************** TEST AREA **************************************************//
                    //chose lowest card, unless there are no cards in the deck

                    //store the first card that is playable in the index, to compare later
                    if (playableCardsIndex.Count() > 0)
                        cardIndex = playableCardsIndex[0];

                    //if there are multiple cards that can be played
                    if (playableCardsIndex.Count() >= 2)
                    {
                        // check to see which card is the lowest and insert the index of that card to the return variable
                        for (int i = 1; i < playableCardsIndex.Count(); i++)
                        {
                             //play stronger cards if the deck is empty
                             if (!DurakGame.DurakConsole.GameDeck.HasCards())
                             {
                                 //compare current card with the next card
                                 if (!PlayerHand[cardIndex].isStronger( PlayerHand[playableCardsIndex[i]]))
                                 {
                                     //add one to index because game logic subtracts one
                                     cardIndex = playableCardsIndex[i];
                                 }
                             }
                             else
                             {
                                 //compare current card with the next card
                                 if (PlayerHand[cardIndex].isStronger(PlayerHand[playableCardsIndex[i]]))
                                 {
                                     //add one to index because game logic subtracts one
                                     cardIndex = playableCardsIndex[i];
                                 }
                                 //else
                                 //{
                                 //    cardIndex = playableCardsIndex[i + 1];

                                 //}
                             }
                           


                        }

                        //add 1 to index, gamelogic subtracts one later.
                        cardIndex += 1;
                    }
                    //if there is only one playable card select that index + 1
                    else if (playableCardsIndex.Count() == 1)
                    {
                        //cardIndex = playableCardsIndex[0] + 1;
                        cardIndex += 1;
                    }
                    else if (playableCardsIndex.Count() == 0)
                    {

                        //******************************** TEST AREA **************************************************//

                        //if no card was selected chose lowest trump card
                    //if (cardIndex == 0)
                    //{
                        for (int i = 1; i <= this.PlayerCardCount; i++)
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
                for (int i = 1; i <= this.PlayerCardCount; i++)
                {
                    //never play the ace of trump suit, unless its the last card
                    if (!(PlayerHand[i - 1].Rank == Rank.Ace && PlayerHand[i - 1].Suit == DurakGame.DurakConsole.TrumpCard.Suit))
                    {
                        //playableCardsIndex.Add(i - 1);
                        if (PlayerHand[i - 1].Suit == attackingCard.Suit && PlayerHand[i - 1] > attackingCard)
                        {
                            cardIndex = i;
                            break;
                        }
                    }
                }

                //if no card was selected, and the deck is empty defend with a strong card
                if (cardIndex == 0 && !DurakGame.DurakConsole.GameDeck.HasCards())
                {
                    for (int i = 1; i <= this.PlayerCardCount; i++)
                    {
                        //never play the ace of trump suit, unless its the last card
                        if (!(PlayerHand[i - 1].Rank == Rank.Ace && PlayerHand[i - 1].Suit == DurakGame.DurakConsole.TrumpCard.Suit))
                        {
                            if (PlayerHand[i - 1].Suit == DurakGame.DurakConsole.TrumpCard.Suit && PlayerHand[i - 1] > attackingCard)
                            {
                                cardIndex = i;
                                break;
                            }
                        }
                    }
                }
            }  
       

            return cardIndex;
        }
    }
}
