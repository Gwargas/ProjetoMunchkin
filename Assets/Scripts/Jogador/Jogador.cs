using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

[CreateAssetMenu(fileName = "Jogador", menuName = "Scriptable Objects/Jogador")]
public class Jogador : ScriptableObject
{
    private int nivel;
    private int poder;
    private List<string> raca = new List<string>();//Botar um header para n�o ter que importar toda hora
    private List<string> classe = new List<string>();
    private bool morto;
    private Hand mao;

    public int Nivel
    {
        get => nivel;
        set => nivel = value;
    }

    public int Poder
    {
        get => poder;
        set => poder = value;
    }

    public Hand Mao
    {
        get => mao;
    }


    
}
