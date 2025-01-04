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
    void Start()
    {   
        controle = Controle.CreateInstance<Controle>();

        controle.CriaCartas();
        Carta c = controle.BaralhoPorta.CompraCarta();

        controle.CriaJogadores();
        controle.DistribuirCartas();
        controle.JogadorAtual = controle.Jogadores[0];

        maoDisplay.Atualiza(controle);
        controle.TrocaEstado(EstadoPreparacao.CreateInstance<EstadoPreparacao>());
        jogadoresHUD.Atualiza(controle);
    }

    void Update()
    {
        // NullReferenceException: Object reference not set to an instance of an object
        // Controle.RunEstadoAtual () (at Assets/Scripts/ControleScript/Controle.cs:172)
        // GameManager.Update () (at Assets/Scripts/GameManager.cs:40)

        controle.RunEstadoAtual();
    }
}



