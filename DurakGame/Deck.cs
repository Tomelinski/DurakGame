using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DurakGame
{
	public class Deck: enum Suit, List<Card>
	{
		public List<Card> Cards = new List<Card>();
		public void FillDeck()
		{

			public void FillDeck()
			{
				for (int i = 0; i < 52; i++)
				{
					Card.Suit = (Card.Suit) (Math.Floor((decimal)i / 13));
					int perSuit = i % 13 + 2;
					Cards.Add(new Card(perSuit, Suit));
				}
			}

		}
	}
}
