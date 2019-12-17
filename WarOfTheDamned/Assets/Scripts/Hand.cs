using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Hand
{
    public List<ICard> Cards { get; private set; }
    public int MaximumHandSize {get; private set;}

    public Hand(int maximumHandSize)
    {
        MaximumHandSize = maximumHandSize;
        var drawnCards = 0;

        while(drawnCards < MaximumHandSize){
            DrawCard();
        }
    }

    public void DrawCard() { }
    public void PlayCard(ICard card){}
    public void DiscardCard(ICard card) { }
}