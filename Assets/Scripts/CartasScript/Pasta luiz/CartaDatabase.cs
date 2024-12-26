//Luiz
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CartaDatabase : MonoBehaviour
{

    public static List<Card> listacarta = new List<Card> { };

    void Awake()
    {

        listacarta.Add(new Card(0, "nome1", "description1"));
        listacarta.Add(new Card(1, "nome2", "description2"));
        listacarta.Add(new Card(2, "nome3", "description3"));
        foreach (var card in listacarta)
        {
            Debug.Log(card.id);
        }
    }

}