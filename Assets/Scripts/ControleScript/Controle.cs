using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Controle", menuName = "Scriptable Objects/Controle")]

public class Controle : ScriptableObject
{
    private List<Jogador> jogadores = new List<Jogador>();
    private BaralhoPorta baralhoPorta;
    private BaralhoTesouro baralhoTesouro;
    private EstadoJogo estadoAtual;
    private Carta cartaJogo;
    private Jogador jogadorAtual;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    private int turno; 
=======
    private int turno = 0;
>>>>>>> Stashed changes
=======
    private int turno = 0;
>>>>>>> Stashed changes
=======
    private int turno = 0;
>>>>>>> Stashed changes

    public Carta CartaJogo
    {
        get => cartaJogo;
        set => cartaJogo = value;
    }
    public int Turno
    {
        get => turno;
        set => turno = value;
    }

    public BaralhoPorta BaralhoPorta
    {
        get => baralhoPorta;
        set => baralhoPorta = value;
    }

    public BaralhoTesouro BaralhoTesouro
    {
        get => baralhoTesouro;
        set => baralhoTesouro = value;
    }

    public List<Jogador> Jogadores
    {
        get => jogadores;
    }

    public Jogador JogadorAtual
    {
        get => jogadorAtual;
        set => jogadorAtual = value;
    }
    public int Dado()
    {
        return (UnityEngine.Random.Range(1, 7));
    }

    /* (Note: David) REMOVER => Mecânica de estados substitui esses métodos 
    public void Turno(int i)
    {
        Jogador jogador = jogadores[i];
        Carta cartaComprada = baralhoPorta.CompraCarta();
        cartaComprada.EfeitoCompra(this);
        //O que fazer apos tirar a primeira carta de porta
        //... //Implementar a questao de estados
    }

    public void Combate(Jogador jogador, CartaMonstro monstro)
    {
        //VerificaAjuda();
        if (jogador.Bonus > monstro.Nivel){
            for(int i = 0; i < monstro.Recompensa; i++){
                Carta cartaComprada = baralhoTesouro.CompraCarta();
                jogador.Mao.Add(cartaComprada);
            }
            jogador.Nivel = monstro.NiveisAGanhar;
        }

        else{
            int dado = Dado();
            if(dado < 5){
                //Coisa Ruim
            }
        }
    }
    */

    public void DistribuirCartas()
    {
        Carta c;
        for (int i = 0; i < jogadores.Count; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                c = baralhoPorta.CompraCarta();
                jogadores[i].Mao.Add(c);
                c = baralhoTesouro.CompraCarta();
                jogadores[i].Mao.Add(c);
            }
        }
    }

    public void ReviveMorto(Jogador jogador)
    {
        Carta c;
            for(int j = 0; j < 4; j++){
                c = baralhoPorta.CompraCarta();
                jogador.Mao.Add(c);
                c = baralhoTesouro.CompraCarta();
                jogador.Mao.Add(c);
            }
            jogador.Morto = false;
    }

    public void DescartarCartaPorta(CartaPorta c)
    {
        baralhoPorta.Descarte(c);
    }

    public void DescartarCartaTesouro(CartaTesouro c)
    {
        baralhoTesouro.Descarte(c);
    }

    public void CriaJogadores()
    {
        Jogador jogador;
        for (int i = 0; i < GameSettings.qtdJogadores; i++)
        {
            jogador = Jogador.CreateInstance<Jogador>();
            jogador.Nome = "Jogador " + i;
            //resto da inicialização de jogador
            jogadores.Add(jogador);
        }
    }

    public void CriaCartas()
    {

        // B: to achando que isso devia ir pra dentro da classe baralho

        // lista com as informações das cartas de porta
        List<string[]> infosCartaPorta = Extrator.CsvToList("Assets/Resources/porta.csv");

        // lista de cartas de porta
        List<CartaPorta> listaCartasPorta = new List<CartaPorta>();

        // cria as cartas de porta
        foreach (string[] info in infosCartaPorta)
        {
            CartaPorta novaCarta = CreateCartaPorta.Cria(info);
            listaCartasPorta.Add(novaCarta);
        }

        //var xxx = baralhoPorta.Embaralha(listaCartasPorta); //Teste
        baralhoPorta = BaralhoPorta.CreateInstance<BaralhoPorta>();
        baralhoPorta.Inicializa(baralhoPorta.Embaralha(listaCartasPorta)); //Compartilha a  mesma instancia que BaralhoPorta tem no inicio
                                                                           //Entender se isso se encaixa nessa técnica de polimorfismo

        // lista com as informações das cartas de tesouro
        List<string[]> infosCartaTesouro = Extrator.CsvToList("Assets/Resources/tesouro.csv");

        // lista de cartas de tesouro
        List<CartaTesouro> listaCartasTesouro = new List<CartaTesouro>();

        // cria as cartas de tesouro
        foreach (string[] info in infosCartaTesouro)
        {
            CartaTesouro novaCarta = CreateCartaTesouro.Cria(info);
            listaCartasTesouro.Add(novaCarta);
        }

        baralhoTesouro = BaralhoTesouro.CreateInstance<BaralhoTesouro>();
        baralhoTesouro.Inicializa(baralhoTesouro.Embaralha(listaCartasTesouro));

    }

    public void TrocaEstado(EstadoJogo novoEstado)
    {
        estadoAtual = novoEstado;
        estadoAtual.IniciarEstado(this);
    }

    public void RunEstadoAtual()
    {
        estadoAtual.RunEstado(this);
    }

<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public Jogador getJogadorAtual()
    {
        int index = turno % jogadores.Count;
    }


=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
}
