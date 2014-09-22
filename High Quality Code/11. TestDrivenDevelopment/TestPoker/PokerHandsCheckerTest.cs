/* Task 3. Write a class PokerHandsChecker (+ tests) and start implementing the IPokerHandsChecker interface. 
 * Implement the IsValidHand(IHand). A hand is valid when it consists of exactly 5 different cards. */

/* Task 4. Implement IPokerHandsChecker.IsFlush(IHand) method.  */

/* Task 5. Implement IsFourOfAKind(IHand) method. Did you test all the scenarios? */

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace TestPoker
{
    [TestClass]
    public class PokerHandsCheckerTest
    {
        [TestMethod]
        public void PokerHandsCheckerIsValidTestNullHand()
        {
            Hand handToTest = null;
            PokerHandsChecker testChecker = new PokerHandsChecker();
            Assert.AreEqual(false, testChecker.IsValidHand(handToTest));
        }

        [TestMethod]
        public void PokerHandsCheckerIsValidTestHighCount()
        {
            var cardsList = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
            };

            Hand handToCheck = new Hand(cardsList);

            PokerHandsChecker testChecker = new PokerHandsChecker();
            Assert.AreEqual(false, testChecker.IsValidHand(handToCheck));
        }

        [TestMethod]
        public void PokerHandsCheckerIsValidTetstEqualCards()
        {
            var cardsList = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };

            Hand handToCheck = new Hand(cardsList);

            PokerHandsChecker testChecker = new PokerHandsChecker();
            Assert.AreEqual(false, testChecker.IsValidHand(handToCheck));
        }

        [TestMethod]
        public void PokerHandsCheckerIsvalidTestValidCards()
        {
            
            var cardsList = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs)
            };

            Hand handToCheck = new Hand(cardsList);

            PokerHandsChecker testChecker = new PokerHandsChecker();
            Assert.AreEqual(true, testChecker.IsValidHand(handToCheck));
        }

        [TestMethod]
        public void PokerHandsCheckerIsFlushTestInvalidCards()
        {
            var cardsList = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs)
            };

            var hand = new Hand(cardsList);
            var testChecker = new PokerHandsChecker();
            Assert.AreEqual(false, testChecker.IsFlush(hand));
        }

        [TestMethod]
        public void PokerHandsCheckerIsFlushTestValidCards()
        {
            var cardsList = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs)
            };

            var hand = new Hand(cardsList);
            var testChecker = new PokerHandsChecker();
            Assert.AreEqual(true, testChecker.IsFlush(hand));
        }

        [TestMethod]
        public void PokerHandsCheckerIsFourOfAKindTestInvalidCards()
        {
            var cardsList = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs)
            };

            var hand = new Hand(cardsList);
            var testChecker = new PokerHandsChecker();
            Assert.AreEqual(false, testChecker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void PokerHandsCheckerIsFourOfAKindTestValidCards()
        {
            var cardsList = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs)
            };

            var hand = new Hand(cardsList);
            var testChecker = new PokerHandsChecker();
            Assert.AreEqual(true, testChecker.IsFourOfAKind(hand));
        }
    }
}
