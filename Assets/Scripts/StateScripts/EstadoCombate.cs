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
    private List<Jogador> ajudantes = new List<Jogador>();
    private int interferenciaMonstro = 0;
    private int interferenciaJogador = 0;
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
    {
        //nomeJogador = menuInterferencia.transform.Find("NomeJogador").GetComponentInChildren<TextMeshProUGUI>();
        //botaoAjuda = menuInterferencia.transform.Find("BotaoAjuda").GetComponentInChildren<Button>();
        //botaoAtrapalha = menuInterferencia.transform.Find("BotaoAtrapalha").GetComponentInChildren<Button>();
        //menuInterferencia.SetActive(true);
        Interferencia inter = GameObject.FindObjectOfType<Interferencia>();
        inter.IniciarInteracao(controle);
    }

    public override void RunEstado(Controle controle)
    {
        //Debug.Log("Tratando Combate");
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
