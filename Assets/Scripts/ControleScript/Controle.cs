using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Controle", menuName = "Scriptable Objects/Controle")]

//static?????
public class Controle : ScriptableObject
{
    private List<Jogador> jogadores = new List<Jogador>();
    private BaralhoPorta baralhoPorta = new BaralhoPorta();
    private BaralhoTesouro baralhoTesouro = new BaralhoTesouro();
    private EstadoJogo estadoAtual;

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
            Jogador jogador = jogadores[i];
            for(int j = 0; j < 4; j++){
                c = baralhoPorta.CompraCarta();
                jogador.Mao.Add(c);
                c = baralhoTesouro.CompraCarta();
                jogador.Mao.Add(c);
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
    
}
