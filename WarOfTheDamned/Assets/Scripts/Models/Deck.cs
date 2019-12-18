using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Exceptions;
using Interfaces;

namespace Models
{
    public class Deck
    {
        public List<ICard> Cards { get; private set; }
        public List<ICard> DrawableCards { get; private set; }

        public Deck(List<ICard> cards)
        {
            Cards = new List<ICard>(cards);
            Shuffle(cards);
        }

        public void Shuffle(List<ICard> deck)
        {
            var random = new Random();

            List<ICard> shuffledDeck = new List<ICard>();

            var randomIndex = 0;

            while (deck.Count > 0)
            {
                randomIndex = random.Next(0, deck.Count);
                shuffledDeck.Add(deck[randomIndex]);
                deck.RemoveAt(randomIndex);
            }

            DrawableCards = shuffledDeck;
        }

        public ICard DrawCard()
        {
            if (DrawableCards.Count() > 0)
            {
                var card = DrawableCards.First();
                DrawableCards.RemoveAt(0);
                return card;
            }

            throw new DeckException("No drawable cards");
        }

        public ICard DrawSelectedCard(string cardId)
        {
            var cardToDraw = DrawableCards.SingleOrDefault(c => c.Id == cardId);

            if (cardToDraw == null)
            {
                throw new DeckException($"Card with ID {cardId} does not exist in Deck");
            }

            DrawableCards.Remove(cardToDraw);
            return cardToDraw;
        }

        public void AddCardToDeck(ICard card)
        {
            Cards.Add(card);
        }

        public void RemoveCardFromDeck(string cardId)
        {
            var cardToRemove = Cards.SingleOrDefault(c => c.Id == cardId);
            if(cardToRemove == null)
            {
                throw new DeckException($"No card with the ID {cardId} exists in the deck");
            }
            
            Cards.Remove(cardToRemove);
        }
    }

}
