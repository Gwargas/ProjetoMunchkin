using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hand", menuName = "Scriptable Objects/Hand")]
public class Hand : ScriptableObject
{

    private List<Carta> naMao = new List<Carta>();
    private List<Carta> emUso = new List<Carta>();


    public void Add(Carta c)
    {
        naMao.Add(c);
    }

    public void equiparItem(Carta c) {
        emUso.Add(c);
    }

    public List<Carta> NaMao
    {
        get => naMao;
        set => naMao = value;
    }

    public List<Carta> EmUso
    {
        get => emUso;
        set => emUso = value;
    }
}
