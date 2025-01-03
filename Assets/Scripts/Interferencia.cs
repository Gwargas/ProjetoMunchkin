using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interferencia : MonoBehaviour
{
    [SerializeField] private GameObject menuInteracao;
    [SerializeField] private TextMeshProUGUI nomeJogador;
    [SerializeField] private Button botaoAjuda;
    [SerializeField] private Button botaoAtrapalha;
    private List<Jogador> ajudantes = new List<Jogador>();
    private List<Carta> cartasInterferencia = new List<Carta>();
    private Jogador ajudante;

    public GameObject MenuInteracao
    {
        get => menuInteracao;
    }

    public Jogador Ajudante
    {
        get => ajudante;
    }

    public List<Carta> CartasInterferencia
    {
        get => cartasInterferencia;
    }

    public void IniciarInteracao(Controle controle, Action onInteracaoCompleta)
    {
        StartCoroutine(Interferir(controle, onInteracaoCompleta));
    }

    public IEnumerator Interferir(Controle controle, Action onInteracaoCompleta)
    {
        //Debug.Log("Iniciou o metodo");
        List<Jogador> jogadoresRestantes = controle.Jogadores.Where(j => j != controle.JogadorAtual).ToList();
        //Debug.Log("Jogadores Restantes: " + jogadoresRestantes.Count);
        menuInteracao.SetActive(true);
        bool botaoAjudaClick = false;
        bool botaoAtrapalhaClick = false;
        //Debug.Log("antes do foreach");
        foreach(Jogador jogador in jogadoresRestantes){

            nomeJogador.text = jogador.Nome;

            botaoAjuda.onClick.RemoveAllListeners();
            botaoAtrapalha.onClick.RemoveAllListeners();

            botaoAjuda.onClick.AddListener(() => {
                ajudantes.Add(jogador);
                Debug.Log("Clicou na ajuda");
                botaoAjudaClick = true;
            });

            botaoAtrapalha.onClick.AddListener(() => {
                // Tratar quais cartas podem interferir (so aumenta monstro ou outras)
                // lidar com a visualização das cartas que podem interferir para escolha
                // Atenção em questão de descarte do monstro (resetar o monstro ao seu original)
                // adicionar as cartas de interferencia na lista
                Debug.Log("Clicou em atrapalhar");
                botaoAtrapalhaClick = true;
            });
            //Debug.Log("Antes do wait");
            yield return new WaitUntil(() => botaoAjudaClick || botaoAtrapalhaClick);

            botaoAjudaClick = false;
            botaoAtrapalhaClick = false;
        }
        //Debug.Log("Terminou o loop");
        menuInteracao.SetActive(false);

        onInteracaoCompleta?.Invoke();
    }
}
