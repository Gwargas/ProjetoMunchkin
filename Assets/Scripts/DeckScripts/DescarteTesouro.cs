using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "DescarteTesouro", menuName = "Scriptable Objects/DescarteTesouro")]
public class DescarteTesouro : Deck
{
    [SerializeField] List<Carta> baralhoDescarteT;

    public void EmbaralharP()
    {
        baralhoDescarteT = baralhoDescarteT.OrderBy(x => UnityEngine.Random.Range(0f, 1f)).ToList();
    }

    public override void CompraCarta()
    {

        //vai ser nulo a fun��o compra ou n�o teremos a fun��o compra como abstrata?
        //throw new System.NotImplementedException();
    }

}
