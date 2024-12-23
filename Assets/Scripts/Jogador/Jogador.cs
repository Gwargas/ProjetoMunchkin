using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

[CreateAssetMenu(fileName = "Jogador", menuName = "Scriptable Objects/Jogador")]
public class Jogador : ScriptableObject
{
    int nivel;
    int poder;
    List<string> raca = new List<string>();//Botar um header para não ter que importar toda hora
    List<string> classe = new List<string>();
    bool morto;


    
}
