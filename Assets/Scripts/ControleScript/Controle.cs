using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Controle", menuName = "Scriptable Objects/Controle")]

public class Controle : ScriptableObject
{
    private List<Jogador> jogadores = new List<Jogador>();
    private Deck baralhoPorta = new BaralhoPorta();
    private Deck baralhoTesouro = new BaralhoTesouro();
    private EstadoJogo estadoAtual;
    private Carta cartaJogo;

    public Carta CartaJogo
    {
        get => cartaJogo;
        set => cartaJogo = value;
    }

    public Deck BaralhoPorta
    {
        get => baralhoPorta;
        set => baralhoPorta = value;
    }
    public Deck BaralhoTesouro
    {
        get => baralhoTesouro;
        set => baralhoTesouro = value;
    }
    public int Dado()
    {
        return(UnityEngine.Random.Range(1, 7));
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
        for(int i = 0; i < jogadores.Count; i++){
            for(int j = 0; j < 4; j++){
                c = baralhoPorta.CompraCarta();
                jogadores[i].Mao.Add(c);
                c = baralhoTesouro.CompraCarta();
                jogadores[i].Mao.Add(c);
            }
        }
    }

    public void DescartarCartaPorta(Carta c)
    {
        baralhoPorta.Descarte(c);
    }

    public void DescartarCartaTesouro(Carta c)
    {
        baralhoTesouro.Descarte(c);
    }

    public void CriaJogadores()
    {
        Jogador jogador;
        for(int i = 0; i < GameSettings.qtdJogadores; i++){
            jogador = new Jogador();
            //resto da inicialização de jogador
            jogadores.Add(jogador);
        }
    }

    public void CriaCartas() {

        // B: to achando que isso devia ir pra dentro da classe baralho

        // lista com as informações das cartas de porta
        List<string[]> infosCartaPorta = Extrator.CsvToList("Factory/porta.csv");

        // lista de cartas de porta
        List<CartaPorta> listaCartasPorta = new List<CartaPorta>();

        // cria as cartas de porta
        foreach (string[] info in infosCartaPorta) {
            CartaPorta novaCarta = CreateCartaPorta.Cria(info);
            listaCartasPorta.Add(novaCarta);
        }

        // AI VOCÊ TEM QUE COLOCAR NO DECK DE CARTAS DE PORTA

        // lista com as informações das cartas de tesouro
        List<string[]> infosCartaTesouro = Extrator.CsvToList("Factory/tesouro.csv");
        
        // lista de cartas de tesouro
        List<CartaTesouro> listaCartasTesouro = new List<CartaTesouro>();

        // cria as cartas de tesouro
        foreach (string[] info in infosCartaTesouro) {
            CartaTesouro novaCarta = CreateCartaTesouro.Cria(info);
            listaCartasTesouro.Add(novaCarta);
        }

        // AI VOCÊ TEM QUE COLOCAR NO DECK DE CARTAS DE TESOURO
    
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

    public void Interferir()
    {
        throw new System.NotImplementedException();
        // Tela de opções 
    }

    /*public Jogador getJogadorAtual()
    {
        int index =
    }*/

}
