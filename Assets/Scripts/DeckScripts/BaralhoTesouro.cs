using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "BaralhoTesouro", menuName = "Scriptable Objects/BaralhoTesouro")]

public class BaralhoTesouro : Deck<CartaTesouro>
{

    public override void Inicializa(List<CartaTesouro> c)
    {
        // Cannot implicitly convert type 'System.Collections.Generic.List<Carta>' to 'System.Collections.Generic.List<CartaTesouro>'CS0029
        this.baralho = c;
    }

    public override Carta CompraCarta()
    {
        if (baralho.Count == 0){
            Debug.Log("Baralho vazio, embaralhando descarte");
            baralho = Embaralha(descarte);
            descarte.Clear();
        }
        Carta cartaComprada = baralho[0];
        baralho.RemoveAt(0);
        return cartaComprada;
    }

    public override List<CartaTesouro> Embaralha(List<CartaTesouro> l)
    {
        return l.OrderBy(x => UnityEngine.Random.Range(0f, 1f)).ToList();
    }

    public override void Descarte(CartaTesouro c)
    {
        descarte.Add(c);
        Debug.Log("Descarte " + descarte[^1].Nome);
    }

}
