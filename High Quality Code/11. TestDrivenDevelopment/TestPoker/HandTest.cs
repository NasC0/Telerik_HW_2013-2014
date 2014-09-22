// Task 2. Write a class Hand implementing the IHand interface. Implement the properties. Write a constructor. Implement the ToString() method. Test all cases.


using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;
using System.Text;

namespace TestPoker
{
    [TestClass]
    public class HandTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HandConstructorTestNullList()
        {
            IList<ICard> cardList = null;
            Hand handToTest = new Hand(cardList);
        }

        [TestMethod]
        public void HandCardsTestGetter()
        {
            var cardList = new List<ICard>();
            Hand handToTestGetter = new Hand(cardList);
            Assert.IsTrue(!(object.ReferenceEquals(cardList, handToTestGetter.Cards)));
            Assert.IsTrue(cardList.Count == handToTestGetter.Cards.Count);
        }

        [TestMethod]
        public void HandToStringTest()
        {
            var cardList = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs)
            };

            StringBuilder expectedResult = new StringBuilder();
            expectedResult.AppendLine("Ace of Spades");
            expectedResult.AppendLine("Eight of Hearts");
            expectedResult.AppendLine("Five of Diamonds");
            expectedResult.AppendLine("Four of Clubs");
            expectedResult.AppendLine("Jack of Clubs");

            Hand handToTest = new Hand(cardList);

            Assert.AreEqual(expectedResult.ToString(), handToTest.ToString());
        }
    }
}
