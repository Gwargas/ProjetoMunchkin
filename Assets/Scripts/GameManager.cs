using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public Controle controle;
    //public static List<Carta> listacarta = new List<Carta> { };

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {
        //controle = new Controle();
        controle = Controle.CreateInstance<Controle>();

        //listacarta.Add(new CartaMonstro());

        //criar carta e dps add em Deck(em cada baralho)
        //Bea vai instanciar as cartas
        controle.CriaCartas();
        Carta c = controle.BaralhoPorta.CompraCarta();

        controle.CriaJogadores();

        //controle.DistribuirCartas();
        controle.JogadorAtual = controle.Jogadores[0];
        controle.TrocaEstado(EstadoPreparacao.CreateInstance<EstadoPreparacao>());
    }

    void Update()
    {
        // NullReferenceException: Object reference not set to an instance of an object
        // Controle.RunEstadoAtual () (at Assets/Scripts/ControleScript/Controle.cs:172)
        // GameManager.Update () (at Assets/Scripts/GameManager.cs:40)
        controle.RunEstadoAtual();
    }
}



