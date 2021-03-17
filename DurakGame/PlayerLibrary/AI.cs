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
        // Default Constructor
        public AI() { }

        // Grabbing the deck to fill the hands
        public AI(Deck playingDeck) : base(playingDeck.ToString()) { }


        /// <summary>
        /// Chooses the lowest Card in Hand
        /// </summary>
        /// <param name="handIndex"> The number of the actual card </param>

        public Card chooseCard(Cards handIndex)
        {
            // Initializes the cards
            Cards chosenCards = this.PlayCard(handIndex);
            int numCard = chosenCards.Count;

            // Grabs the Lowest Card
            Card dropCard = chosenCards[lowestCard(chosenCards)];

            chosenCards.Remove(dropCard);

            return dropCard;
        }

        /// <summary>
        /// Looks for the lowest card in the group
        /// </summary>
        /// <param name="lCard"> The group which is searched to find the lowest card </param>
        public int lowestCard(Cards lCard)
        {
            int cardIndex = 0;
            for (int i = 0; i < lCard.Count; i++)
            {
                if (lCard[i] < (lCard[cardIndex]))
                {
                    cardIndex = i;
                }
            }
            return cardIndex;
        }
    }
}
