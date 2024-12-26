//Luiz
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Card
{
    public int id;
    public string cardname;
    public string description;
    public Card()
    {

    }

    public Card(int Id, string Cardname, string Description)
    {
        id = Id;
        cardname = Cardname;
        description = Description;
    }

}