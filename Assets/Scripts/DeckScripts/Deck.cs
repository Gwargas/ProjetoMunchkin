using System.Collections.Generic;
using UnityEngine;

public abstract class Deck : ScriptableObject
{
    protected List<Carta> descarte = new List<Carta>();
    protected List<Carta> baralho = new List<Carta>();


    public abstract Carta CompraCarta();

    public abstract List<Carta> Embaralha(List<Carta> l);

    public abstract void Descarte(Carta c);
    
}
