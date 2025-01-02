using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "BaralhoPorta", menuName = "Scriptable Objects/BaralhoPorta")]
public class BaralhoPorta : Deck<CartaPorta>
{
    public BaralhoPorta(){}
    public BaralhoPorta(List<CartaPorta> c)
    {
        this.baralho = c;
    }

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

    public override List<CartaPorta> Embaralha(List<CartaPorta> l)
    {
        return l.OrderBy(x => UnityEngine.Random.Range(0f, 1f)).ToList();
    }

    public override void Descarte(CartaPorta c){
        descarte.Add(c);
    }
}
