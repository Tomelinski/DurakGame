/* CardOutOfRangeExceptio.cs - This file contains a Custom Exception. It contains the
 *                           CardOutOfRangeException. This Exception will get thrown when
 *                           an index of less than 0 or greater than the deck size is attempted
 *                           to be accessed.
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
    class CardOutOfRangeException : Exception
    {
        // A list of cards, from the deck
        private Cards deckContents;
        public Cards DeckContents
        {
            get
            {
                return deckContents;
            }
        }
        public CardOutOfRangeException(Cards sourceDeckContents)
        : base("There are only 52 cards in the deck.")
        {
            deckContents = sourceDeckContents;
        }
    }
}
