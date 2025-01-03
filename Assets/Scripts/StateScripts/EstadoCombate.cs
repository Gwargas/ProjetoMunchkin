using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EstadoCombate : EstadoJogo
{
    private Jogador ajudante;
    private List<Carta> cartasInterferencia;
    Interferencia[] refs;
    Interferencia inter;

    //private int interferenciaMonstro = 0;
    //private int interferenciaJogador = 0;
    //private GameObject menuInterferencia;
    //private TextMeshProUGUI nomeJogador;
    //private Button botaoAjuda;
    //private Button botaoAtrapalha;

    /*public GameObject MenuInterferencia
    {
        get => menuInterferencia;
        set => menuInterferencia = value;
    }*/
    
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
            //Movimentação de cartas do JogadorAtual...
            inter.IniciarEscolhaAjudante(controle, (Jogador ajudanteEscolhido) =>
            {
                ajudante = ajudanteEscolhido;
                TratarCombate(controle);
            });
        });
    }

    public override void RunEstado(Controle controle)
    {
        //Debug.Log("Tratando Combate");
    }
    
    public void TratarCombate(Controle controle)
    {   
        Debug.Log("Tratando Combate");
        //Achar uma solucao melhor para essa parte, sem o uso do C
        CartaMonstro monstro = (CartaMonstro)controle.CartaJogo;
        foreach(Carta carta in cartasInterferencia){
            carta.Efeito.Apply(controle);
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
        controle.TrocaEstado(EstadoFimTurno.CreateInstance<EstadoFimTurno>());
        
    }

    
    /*public void Interferir(Controle controle, EstadoCombate estadoCombate)
    {
        List<Jogador> jogadoresRestantes = controle.Jogadores.Where(j => j != controle.JogadorAtual).ToList();
        //Debug.Log("Jogadores Restantes: " + jogadoresRestantes.Count);
        menuInterferencia.SetActive(true);
        bool botaoAjudaClick = false;
        bool botaoAtrapalhaClick = false;

        botaoAjuda.onClick.AddListener(() => {
            Debug.Log("Clicou na ajuda");
            botaoAjudaClick = true;
        });

        botaoAtrapalha.onClick.AddListener(() => {
            Debug.Log("Clicou em atrapalhar");
            botaoAtrapalhaClick = true;
        });

        for (int i = 0; i < jogadoresRestantes.Count; i++){
            Debug.Log("Iteracao: " + i);
            nomeJogador.text = jogadoresRestantes[i].Nome;
            
            if (botaoAjudaClick || botaoAtrapalhaClick){
                botaoAjudaClick = false;
                botaoAtrapalhaClick = false;
                continue;
            }
        }
        
        //menuInterferencia.SetActive(false);

    }*/

    
}
