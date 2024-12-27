using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hand", menuName = "Scriptable Objects/Hand")]
public class Hand : ScriptableObject
{

    private List<Carta> carregada = new List<Carta>();
    private List<Carta> naMao = new List<Carta>();
    private List<Carta> emUso = new List<Carta>();


    public void Add(Carta c)
    {
        naMao.Add(c);
    }

    public void carregarItem(Carta c)
    { 
        naMao.Remove(c);
        carregada.Add(c);
    }

    public void equiparItem(Carta c)
    {
        emUso.Add(c);
    }
    public void desequiparItem(Carta c)
    {
        carregada.Remove(c);
        naMao.Add(c);
    }

}
