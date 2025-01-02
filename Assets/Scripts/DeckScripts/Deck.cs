using System.Collections.Generic;
using UnityEngine;

public abstract class Deck<T> : ScriptableObject where T : Carta
{
    protected List<T> descarte = new List<T>();
    protected List<T> baralho = new List<T>();

    public Deck(){}
    public Deck(List<Carta> c)
    {
    }
    public abstract Carta CompraCarta();

    public abstract List<T> Embaralha(List<T> l);

    public abstract void Descarte(T c);
    

}
