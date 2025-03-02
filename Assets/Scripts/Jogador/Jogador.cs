using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Jogador", menuName = "Scriptable Objects/Jogador")]
public class Jogador : ScriptableObject
{
    private string nome;
    private int nivel = 1;
    private int bonus = 0;
    private string raca = "humano"; //Botar um header para nao ter que importar toda hora
    private string classe = "nada";
    private bool morto = false;
    private Hand mao;

    public void OnEnable()
    {
        mao = Hand.CreateInstance<Hand>();
    }

    public int Nivel
    {
        get => nivel;
        set => nivel = value;
    }

    public int Bonus
    {
        get => bonus;
        set => bonus = value;
    }

    public Hand Mao {
        get => mao;
        set => mao = value;
    }

    public string Nome
    {
        get => nome;
        set => nome = value;
    }
    
    public bool Morto {
        get => morto;
        set => morto = value;
    }

    public string Raca
    {
        get => raca;
        set => raca = value;
    }

    public string Classe
    {
        get => classe;
        set => classe = value;
    }
}
