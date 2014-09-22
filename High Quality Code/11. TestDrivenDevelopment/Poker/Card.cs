using System;
using System.Text;

namespace Poker
{
    public class Card: ICard
    {
        private CardFace face;
        private CardSuit suit;

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face
        {
            get
            {
                return this.face;
            }
            private set
            {
                this.face = value;
            }
        }

        public CardSuit Suit
        {
            get
            {
                return this.suit;
            }
            private set
            {
                this.suit = value;
            }
        }

        public override string ToString()
        {
            StringBuilder cardString = new StringBuilder();
            cardString.Append(this.Face);
            cardString.Append(" of ");
            cardString.Append(this.Suit);
            return cardString.ToString();
        }

        public override bool Equals(object obj)
        {
            var cardObj = (obj as Card);
            if (cardObj == null)
            {
                throw new ArgumentNullException("This method compares only Card objects.");
            }

            if (this.Face == cardObj.Face && this.Suit == cardObj.Suit)
            {
                return true;
            }

            return false;
        }
    }
}
