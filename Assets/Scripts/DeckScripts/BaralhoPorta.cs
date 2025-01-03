using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "BaralhoPorta", menuName = "Scriptable Objects/BaralhoPorta")]
public class BaralhoPorta : Deck<CartaPorta>
{
    public override void Inicializa(List<CartaPorta> c)
    {
        // Cannot implicitly convert type 'System.Collections.Generic.List<Carta>' to 'System.Collections.Generic.List<CartaTesouro>'CS0029
        this.baralho = c;
    }

    public override Carta CompraCarta()
    {
        if (baralho.Count == 0)
        {
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

    public override void Descarte(CartaPorta c)
    {
        descarte.Add(c);
    }
    public List<CartaPorta> Baralho
    {
        get => baralho;
        set => baralho = value;
    }
}
