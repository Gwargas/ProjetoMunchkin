using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EstadoCombate : EstadoJogo
{
    private Jogador ajudante;
    private List<Carta> cartasInterferencia;
    Interferencia[] refs;
    Interferencia inter;
    
    public override void IniciarEstado(Controle controle)
    //Tratar o cara morto,remover suas cartas tanto em mão quanto equipada/carregada mas deixar o nível e cartas classe e raca
    {
        refs = FindObjectsByType<Interferencia>(FindObjectsSortMode.None);
        if(refs[0] != null){
            Debug.Log("Encontrou o gerenciador de interferência");
        }
        inter = refs[0];
        inter.IniciarInteracao(controle, () =>
        {
            cartasInterferencia = inter.CartasInterferencia;
            if(inter.Ajudantes.Count == 0)
            {
                Debug.Log("Sem ajudantes");
                TratarCombate(controle);
            }
            else{
                inter.IniciarEscolhaAjudante(controle, (Jogador ajudanteEscolhido) =>
                {
                    ajudante = ajudanteEscolhido;
                    TratarCombate(controle);
                });
            }
        });
    }

    public override void RunEstado(Controle controle)
    {
        //Debug.Log("Tratando Combate");
    }
    
    public void TratarCombate(Controle controle)
    {   
        Debug.Log("Tratando Combate");
        CartaMonstro monstro = (CartaMonstro)controle.CartaJogo;
        if(cartasInterferencia.Count > 0)
        {
            Debug.Log("Aplicando efeitos de interferencias");
            foreach(Carta carta in cartasInterferencia){
                carta.Efeito.Apply(controle);
            }
        }
        
        int tesouros = monstro.Recompensa;
        int dado;
        if(ajudante != null)
        {
            if(controle.JogadorAtual.Nivel + controle.JogadorAtual.Bonus + ajudante.Nivel + ajudante.Bonus > monstro.Nivel)
            {
                Debug.Log("Venceu o monstro");
                controle.JogadorAtual.Nivel += monstro.NiveisAGanhar;
                
                int cont = 0;
                for(int i = 0; i < (tesouros/2); i++)
                {
                    ajudante.Mao.Add(controle.BaralhoTesouro.CompraCarta());
                    cont++;
                }
                for(int j = 0; j< tesouros - cont; j++)
                {
                    controle.JogadorAtual.Mao.Add(controle.BaralhoTesouro.CompraCarta());
                }

            }
            else{
                dado = controle.Dado();
                if(dado < 5){
                    Debug.Log("Perdeu o combate, recebendo Coisa Ruim");
                    monstro.Efeito.Apply(controle);
                }
            }
        }
        else{
            if(controle.JogadorAtual.Nivel + controle.JogadorAtual.Bonus > monstro.Nivel)
            {  
                Debug.Log("Venceu o monstro");
                controle.JogadorAtual.Nivel += monstro.NiveisAGanhar;
                
                for(int k = 0; k < tesouros; k++)
                {
                    controle.JogadorAtual.Mao.Add(controle.BaralhoTesouro.CompraCarta());
                }
            }
            else{
                dado = controle.Dado();
                if(dado<5){
                    Debug.Log("Perdeu o combate, recebendo Coisa Ruim");
                    monstro.Efeito.Apply(controle);
                }
            }
        }
        Debug.Log("Fim do Combate");
        if(controle.JogadorAtual.Nivel >= 10){
            GameSettings.vencedor = controle.JogadorAtual;
            SceneManager.LoadScene("CenaFinal");
        }

        foreach(Carta carta in cartasInterferencia){
            carta.Efeito.Revert(controle);
            controle.BaralhoPorta.Descarte((CartaPorta)carta);
        }
        controle.BaralhoPorta.Descarte(monstro);

        inter.CartasInterferencia.Clear();
        //inter.CartasInterferencia.TrimExcess();
        inter.Ajudantes.Clear();
        //inter.Ajudantes.TrimExcess();
        controle.TrocaEstado(EstadoFimTurno.CreateInstance<EstadoFimTurno>());
        
    }
    
}
