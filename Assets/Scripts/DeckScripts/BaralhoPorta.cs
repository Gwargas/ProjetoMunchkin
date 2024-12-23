using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaralhoPorta", menuName = "Scriptable Objects/BaralhoPorta")]
public class BaralhoPorta : Deck
{
    [SerializeField] List<Carta> baralhoPorta;

    /*
    public Carta CompraCartaPorta()
    {
        return baralhoPorta[0];
    }
    */

    /*
    public void EmbaralhaPorta()
    {

    }
    */
    public override void CompraCarta()
    {
        //throw new System.NotImplementedException();
    }
}
