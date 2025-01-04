using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Controle controle;
    //public static List<Carta> listacarta = new List<Carta> { };
    [SerializeField] private JogadoresHUD jogadoresHUD;
    [SerializeField] private MaoDisplay maoDisplay;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    void Start() {   
        //controle = new Controle();
        controle = Controle.CreateInstance<Controle>();

        //listacarta.Add(new CartaMonstro());

        //criar carta e dps add em Deck(em cada baralho)
        //Bea vai instanciar as cartas
        controle.CriaCartas();
        Carta c = controle.BaralhoPorta.CompraCarta();

        controle.CriaJogadores();

        controle.DistribuirCartas();
        controle.JogadorAtual = controle.Jogadores[0];
        maoDisplay.Atualiza(controle);
        controle.TrocaEstado(EstadoPreparacao.CreateInstance<EstadoPreparacao>());

        jogadoresHUD.Atualiza(controle);
    }

    void Update() {
        controle.RunEstadoAtual();
    }
}