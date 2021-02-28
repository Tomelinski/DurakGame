using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// CloneCard Class taken from Chapter 12 Card Lib in Textbook
/// </summary>

namespace CardLibrary
{
   public class CLoneCards : List<Card>, ICloneable
   {
      /// <summary>
      /// Utility method for copying card instances into another Cards
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
         Cards newCards = new Cards();
         foreach (Card sourceCard in this)
         {
            newCards.Add((Card)sourceCard.Clone());
         }
         return newCards;
      }
   }
}
