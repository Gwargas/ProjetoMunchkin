using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaralhoTesouro", menuName = "Scriptable Objects/BaralhoTesouro")]
public class BaralhoTesouro : Deck
{
    [SerializeField] List<Carta> baralhoTesouro;

    /*
    public Carta CompraCartaTesouro()
    {
        return baralhoPorta[0];
    }
    */

    /*
    public void EmbaralhaTesouro()
    {

    }
    */
}
