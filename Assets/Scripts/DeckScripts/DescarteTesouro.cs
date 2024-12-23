using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "DescarteTesouro", menuName = "Scriptable Objects/DescarteTesouro")]
public class DescarteTesouro : ScriptableObject
{
    [SerializeField] List<Carta> baralhoDescarteT;

    public void EmbaralharP()
    {
        baralhoDescarteT = baralhoDescarteT.OrderBy(x => UnityEngine.Random.Range(0f, 1f)).ToList();
    }
}
