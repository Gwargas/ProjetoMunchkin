using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "BaralhoTesouro", menuName = "Scriptable Objects/BaralhoTesouro")]
public class BaralhoTesouro : Deck
{
    public override Carta CompraCarta()
    {
        if (baralho.Count == 0){
            baralho = Embaralha(descarte);
            descarte.Clear();
        }
        Carta cartaComprada = baralho[0];
        baralho.RemoveAt(0);
        return cartaComprada;
    }

    public override List<Carta> Embaralha(List<Carta> l)
    {
        return l.OrderBy(x => UnityEngine.Random.Range(0f, 1f)).ToList();
    }

    public override void Descarte(Carta c)
    {
        descarte.Add(c);
    }
}
