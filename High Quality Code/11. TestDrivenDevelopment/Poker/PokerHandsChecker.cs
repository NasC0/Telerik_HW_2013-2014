using System;
using System.Collections.Generic;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                return false;
            }

            if (hand.Cards.Count != 5)
            {
                return false;
            }

            var handCards = hand.Cards;
            for (int i = 0; i < handCards.Count - 1; i++)
            {
                for (int j = i + 1; j < handCards.Count; j++)
                {
                    if (handCards[i].Equals(handCards[j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            Dictionary<CardFace, int> availableHands = new Dictionary<CardFace, int>();
            availableHands.Add(CardFace.Two, 0);
            availableHands.Add(CardFace.Three, 0);
            availableHands.Add(CardFace.Four, 0);
            availableHands.Add(CardFace.Five, 0);
            availableHands.Add(CardFace.Six, 0);
            availableHands.Add(CardFace.Seven, 0);
            availableHands.Add(CardFace.Eight, 0);
            availableHands.Add(CardFace.Nine, 0);
            availableHands.Add(CardFace.Ten, 0);
            availableHands.Add(CardFace.Jack, 0);
            availableHands.Add(CardFace.Queen, 0);
            availableHands.Add(CardFace.King, 0);
            availableHands.Add(CardFace.Ace, 0);

            foreach (var card in hand.Cards)
            {
                availableHands[card.Face]++;
            }

            foreach (var combination in availableHands)
            {
                if (combination.Value == 4)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }
            
            var handCards = hand.Cards;
            for (var i = 0; i < handCards.Count - 1; i++)
            {
                var currentCard = handCards[i];
                if (currentCard.Suit != handCards[i + 1].Suit)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
