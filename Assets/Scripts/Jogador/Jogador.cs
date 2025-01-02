using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

[CreateAssetMenu(fileName = "Jogador", menuName = "Scriptable Objects/Jogador")]
public class Jogador : ScriptableObject
{
    private string nome;
    private int nivel = 1;
    private int bonus = 0;
    private List<string> raca = new List<string>(); //Botar um header para nao ter que importar toda hora
    private List<string> classe = new List<string>();
    private bool morto = false;
    private Hand mao = new Hand();

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

    public Hand Mao
    {
        get => mao;
    }

    public string Nome
    {
        get => nome;
        set => nome = value;
    }
    
}
