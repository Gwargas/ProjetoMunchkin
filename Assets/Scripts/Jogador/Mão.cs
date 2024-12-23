using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hand", menuName = "Scriptable Objects/Hand")]
public class Hand : ScriptableObject
{

    List<Carta> carregada = new List<Carta>();
    List<Carta> naMao = new List<Carta>();
    List<Carta> emUso = new List<Carta>();


    public void carregarItem(Carta c){ 
    
    }
    public void equiparItem(Carta c)
    {

    }
    public void desequiparItem(Carta c)
    {

    }

}
