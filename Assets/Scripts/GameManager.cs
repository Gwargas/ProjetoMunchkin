using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Controle controle;
    //public static List<Carta> listacarta = new List<Carta> { };

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {   
        controle = new Controle();
        //criar carta e dps add em Deck(em cada baralho)
        //listacarta.Add(new CartaMonstro());
        //Bea vai instanciar as cartas
        //Teste::
        controle.CriaJogadores();
        //controle.CriaCartas();
        //controle.DistribuirCartas();
        controle.JogadorAtual = controle.Jogadores[0];
        controle.TrocaEstado(new EstadoPreparacao());
        //
        //criações de todas as insts(deck,carta,jogador...)
    }

    void Update()
    {
        controle.RunEstadoAtual();
    }
}



