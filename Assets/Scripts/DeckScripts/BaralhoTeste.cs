//Luiz
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BaralhoTeste : MonoBehaviour
{
    Controle controle;
    public BaralhoPorta deck;

    public List<CartaPorta> container = new List<CartaPorta>();

    public int x;
    public static int deckSize;

    public GameObject CardtoHand;
    public GameObject[] Clones;
    public GameObject Hand;

    void Start()
    {
        controle = new Controle();
        controle.CriaCartas();
        deck = controle.BaralhoPorta;

    }

}
