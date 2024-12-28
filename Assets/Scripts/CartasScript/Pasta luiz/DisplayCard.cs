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

    public bool cardBack;
    public static bool staticCardBack;

    public GameObject Hand;
    public int numberOfCardsInDeck;
    void Start()
    {
        displayCard[0] = CartaDatabase.listacarta[displayId];
        numberOfCardsInDeck = PlayerDeck.deckSize;

    }
    void Update()
    {

        id = displayCard[0].id;
        Cardname = displayCard[0].cardname;
        Description = displayCard[0].description;
        nametext.text = Cardname;
        desctext.text = Description;

        Hand = GameObject.Find("Hand");
        if (this.transform.parent == Hand.transform.parent)
        {
            cardBack = false;
        }
        staticCardBack = cardBack;
        if (this.tag == "Clone")
        {
            displayCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";
        }

    }
}
