using System;
using UnityEngine;

public interface ICard
{
    string Id {get;set;}
    void Play();
    void Discard();
    void Exile();
}


