using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        private IList<ICard> cards;

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards
        {
            get
            {
                return new List<ICard>(this.cards);
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Hand card list cannot be null.");
                }

                this.cards = value;
            }
        }

        public override string ToString()
        {
            StringBuilder handString = new StringBuilder();
            foreach (var card in this.Cards)
            {
                handString.AppendLine(card.ToString());
            }

            return handString.ToString();
        }
    }
}
