// Task 1. Write a class Card implementing the ICard interface. Implement the properties. Write a constructor. Implement the ToString() method. Test all cases.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace TestPoker
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void CardToStringTest()
        {
            string expectedResult = "Ace of Spades";
            CardSuit cardSuit = CardSuit.Spades;
            CardFace cardFace = CardFace.Ace;
            Card cardToTest = new Card(cardFace, cardSuit);
            Assert.AreEqual(expectedResult, cardToTest.ToString());
        }
    }
}
