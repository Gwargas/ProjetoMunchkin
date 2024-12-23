using System.Collections.Generic;
using UnityEngine;
using System.Linq; // para usar o Order By

[CreateAssetMenu(fileName = "DescartePorta", menuName = "Scriptable Objects/DescartePorta")]
public class DescartePorta : Deck
{
    [SerializeField] List<Carta> baralhoDescarteP;

    public void EmbaralharP()
    {
        baralhoDescarteP = baralhoDescarteP.OrderBy(x => UnityEngine.Random.Range(0f, 1f)).ToList();
    }
}
