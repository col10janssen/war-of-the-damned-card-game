using Assets.Scripts.Exceptions;
using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class DeckTests
    {
        Deck deck;
        List<ICard> cardList;

        private void SetUpTestDeck()
        {
            cardList = new List<ICard>() {
                new GenericCard(),
                new GenericCard(),
                new GenericCard(),
                new GenericCard(),
                new GenericCard(),
                new GenericCard(),
                new GenericCard(),
                new GenericCard(),
                new GenericCard(),
                new GenericCard(),
                new GenericCard(),
                new GenericCard(),
                new GenericCard(),
                new GenericCard(),
                new GenericCard(),
                new GenericCard(),
                new GenericCard(),
                new GenericCard(),
                new GenericCard(),
                new GenericCard()
            };

            deck = new Deck(cardList);
        }

        [TestMethod]
        public void InitilizeDeck()
        {
            SetUpTestDeck();

            Assert.AreEqual(20, deck.Cards.Count);
        }

        [TestMethod]
        public void ShuffleDeck()
        {
            SetUpTestDeck();

            var firstCard = deck.DrawableCards.First();
            var lastCard = deck.DrawableCards.Last();

            deck.Shuffle(deck.DrawableCards);

            var firstShuffledCard = deck.DrawableCards.First();
            var lastShuffledCard = deck.DrawableCards.First();

            Assert.AreNotEqual(firstCard, firstShuffledCard);
            Assert.AreNotEqual(lastCard, lastShuffledCard);
        }

        [TestMethod]
        public void DrawCard()
        {
            SetUpTestDeck();

            var firstCard = deck.DrawableCards.First();

            var drawnCard = deck.DrawCard();

            Assert.AreEqual(19, deck.DrawableCards.Count);
            Assert.IsNotNull(drawnCard);
            Assert.AreEqual(drawnCard, firstCard);
        }

        [TestMethod]
        public void DrawCard_Exception()
        {
            cardList = new List<ICard>() { new GenericCard() };
            deck = new Deck(cardList);

            deck.DrawCard();

            Assert.ThrowsException<DeckException>(() => deck.DrawCard());
        }

        [TestMethod]
        public void DrawSelectedCard()
        {
            SetUpTestDeck();

            var secondCard = deck.DrawableCards[1];

            var drawnCard = deck.DrawSelectedCard(secondCard.Id);

            Assert.AreEqual(19, deck.DrawableCards.Count);
            Assert.IsNotNull(drawnCard);
            Assert.AreEqual(drawnCard, secondCard);
        }

        [TestMethod]
        public void DrawSelectedCard_Exception()
        {
            SetUpTestDeck();
            Assert.ThrowsException<DeckException>(() => deck.DrawSelectedCard(""));
        }

        [TestMethod]
        public void AddCardToDeck()
        {
            SetUpTestDeck();
            deck.AddCardToDeck(new GenericCard());
            Assert.AreEqual(21, deck.Cards.Count);
        }

        [TestMethod]
        public void RemoveCardFromDeck()
        {
            SetUpTestDeck();
            var cardToRemove = new GenericCard();
            deck.AddCardToDeck(cardToRemove);

            deck.RemoveCardFromDeck(cardToRemove.Id);

            Assert.AreEqual(20, deck.Cards.Count);
            Assert.IsFalse(deck.Cards.Contains(cardToRemove));
        }

        [TestMethod]
        public void RemoveCardFromDeck_Exception()
        {
            SetUpTestDeck();

            Assert.ThrowsException<DeckException>(() => deck.RemoveCardFromDeck("test"));
        }
    }
}
