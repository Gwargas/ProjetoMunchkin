//Luiz
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new List<Card>();
    public int displayId;
    public int id;
    public string Cardname;
    public string Description;

    public TextMeshProUGUI nametext;
    public TextMeshProUGUI desctext;
    void Start()
    {
        displayCard[0] = CartaDatabase.listacarta[displayId];
        id = displayCard[0].id;
        Cardname = displayCard[0].cardname;
        Description = displayCard[0].description;
        nametext.text = Cardname;
        desctext.text = Description;

    }
    void update()
    {
        id = displayCard[0].id;
        Cardname = displayCard[0].cardname;
        Description = displayCard[0].description;
        nametext.text = Cardname;
        desctext.text = Description;
        foreach (var card in displayCard)
        {
            Debug.Log(card.id);
        }
    }
}
