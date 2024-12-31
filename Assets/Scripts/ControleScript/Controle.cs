using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Controle", menuName = "Scriptable Objects/Controle")]

public class Controle : ScriptableObject
{
    private List<Jogador> jogadores = new List<Jogador>();
    private Deck baralhoPorta = new BaralhoPorta();
    private Deck baralhoTesouro = new BaralhoTesouro();
    private EstadoJogo estadoAtual;


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

    public void Turno(int i)
    {
        Jogador jogador = jogadores[i];
        Carta cartaComprada = baralhoPorta.CompraCarta();
        cartaComprada.EfeitoCompra();
        //O que fazer apos tirar a primeira carta de porta
        //... //Implementar a questao de estados
    }

    public void Combate(Jogador jogador, CartaMonstro monstro)
    {
        //VerificaAjuda();
        if (jogador.Poder > monstro.Nivel){
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

    public void TrocaEstado(EstadoJogo novoEstado)
    {
        estadoAtual = novoEstado;
        estadoAtual.IniciarEstado(this);
    }

    public void RunEstadoAtual()
    {
        estadoAtual.RunEstado(this);
    }

}
