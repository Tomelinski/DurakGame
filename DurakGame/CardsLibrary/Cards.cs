/* Cards.cs - This file contains the Cards class. It is a collection of 
 *         Card Objects.
 *         
 * Author(s): Beginning C# 7 Programming with Visual Studio 2017
 *            Calvin May
 *            
 * Date: 02/07/2021 | Last Modified: 02/21/2021
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public class Cards : List<Card>, ICloneable // Interface with the ICloneable Interface (Now me must implement the Clone() function)
    {
        
        /// <summary>
        ///     Utility method for copying card instances into another Cards
        /// instance—used in Deck.Shuffle(). This implementation assumes that
        /// source and target collections are the same size.
        /// </summary>
        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }
        
        public object Clone()
        {
            // Declare a new Collection of Cards
            Cards newCards = new Cards();

            // Loop through each Card in the current Collection
            foreach (Card sourceCard in this)
            {
                // Add the Cards of the old collection to the new Collection
                newCards.Add((Card)sourceCard.Clone());
            }
            // Return the newly filled Card Collectiion
            return newCards;
        }
    }
}