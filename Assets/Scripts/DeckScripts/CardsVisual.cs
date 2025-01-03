//Luiz
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class CardsVisual : MonoBehaviour
{
    public List<CartaPorta> deck = new List<CartaPorta>();
    public BaralhoPorta displayCard = new BaralhoPorta();
    public int displayId;
    public int id;
    public string Cardname;
    public string Description;

    public TextMeshProUGUI nametext;
    public TextMeshProUGUI desctext;
    private CardsVisual visual;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Display(Controle controle)
    {
        deck[0] = controle.BaralhoPorta.Baralho[displayId];


    }
    public void Awake(Controle controle)
    {
        deck[0] = controle.BaralhoPorta.Baralho[displayId];
    }

    // Update is called once per frame
    void Update()
    {
        Cardname = deck[0].Nome;
        Description = deck[0].Descricao;
        nametext.text = Cardname;
        desctext.text = Description;

    }

    public CardsVisual Visual
    {
        get => visual;
        set => visual = value;
    }
}
*/