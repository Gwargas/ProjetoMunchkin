using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Controle", menuName = "Scriptable Objects/Controle")]

//static?????
public class Controle : ScriptableObject
{
    private List<Jogador> jogadores = new List<Jogador>();
    private BaralhoPorta baralho_porta = new BaralhoPorta();
    private BaralhoTesouro baralho_tesouro = new BaralhoTesouro();

    public int Dado()
    {
        return(UnityEngine.Random.Range(1, 7));
    }

    public void Turno(int i)
    {
        Jogador jogador = jogadores[i];
        Carta cartaComprada = baralho_porta.CompraCarta();
        cartaComprada.EfeitoCompra();
        //O que fazer apos tirar a primeira carta de porta
        //...
    }

    public void Combate(Jogador jogador, CartaMonstro monstro)
    {
        //VerificaAjuda();
        if (jogador.Poder > monstro.Nivel){
            for(int i = 0; i < monstro.Recompensa; i++){
                Carta cartaComprada = baralho_tesouro.CompraCarta();
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
                c = baralho_porta.CompraCarta();
                jogador.Mao.Add(c);
                c = baralho_tesouro.CompraCarta();
                jogador.Mao.Add(c);
            }
        }
    }

    public void DescartarCartaPorta(Carta c)
    {
        baralho_porta.Descarte(c);
    }

    public void DescartarCartaTesouro(Carta c)
    {
        baralho_tesouro.Descarte(c);
    }
    
}
