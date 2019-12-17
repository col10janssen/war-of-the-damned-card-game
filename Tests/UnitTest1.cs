using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InitilizeDeck()
        {
            var cardList = new List<ICard>() { new GenericCard(), new GenericCard(), new GenericCard() };
            var deck = new Deck(cardList);

            Assert.AreEqual(3, deck.Cards.Count);
        }
    }
}
