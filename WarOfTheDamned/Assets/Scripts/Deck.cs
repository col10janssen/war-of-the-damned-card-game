using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Deck
{
    public List<ICard> Cards { get; private set; }
    public List<ICard> DrawableCards { get; private set; }

    public Deck(List<ICard> cards)
    {
        Cards = cards;
        DrawableCards = cards;
        Shuffle(DrawableCards);
    }

    public void Shuffle(List<ICard> deck)
    {
        var random = new Random();

        List<ICard> shuffledDeck = new List<ICard>();

        int randomIndex = 0;

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

        throw new Exception("No drawable cards");

    }

    public ICard DrawSelectedCard(string cardId)
    {
        var cardToDraw = DrawableCards.Single(c => c.Id == cardId);
        DrawableCards.Remove(cardToDraw);
        return cardToDraw;
    }

    public void AddCardToDeck(ICard card)
    {
        Cards.Add(card);
    }
    public void RemoveCardFromDeck(ICard card)
    {
        var cardToRemove = Cards.Single(c => c.Id == card.Id);
        Cards.Remove(cardToRemove);
    }
}


