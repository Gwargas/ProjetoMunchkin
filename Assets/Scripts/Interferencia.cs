using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
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


    [SerializeField] private GameObject menuAjudantes;
    [SerializeField] private Transform listaAjudantesBox;
    [SerializeField] private GameObject prefabAjudante;
    //private bool recusou = false;
    [SerializeField] private Button botaoRecusar;

    [SerializeField] private Transform painelCartasInterferencia;
    [SerializeField] private Button botaoIgnorar;
    [SerializeField] private CartaDisplay cartaDisplay;

    private List<Carta> cartasDeAumentaMonstro = new List<Carta>();

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
        set => cartasInterferencia = value;
    }

    public List<Jogador> Ajudantes
    {
        get => ajudantes;
        set => ajudantes = value;
    }

    public void IniciarInteracao(Controle controle, Action onInteracaoCompleta)
    {
        StartCoroutine(Interferir(controle, onInteracaoCompleta));
    }

    public IEnumerator Interferir(Controle controle, Action onInteracaoCompleta)
    {
        List<Jogador> jogadoresRestantes = controle.Jogadores.Where(j => j != controle.JogadorAtual).ToList();
        menuInteracao.SetActive(true);
        bool botaoAjudaClick = false;
        bool botaoAtrapalhaClick = false;
        bool botaoIgnorarClick = false;

        foreach(Jogador jogador in jogadoresRestantes){

            Debug.Log("COMEÇO DO FOREACH: ");
            cartasDeAumentaMonstro.Clear();
            cartasDeAumentaMonstro.TrimExcess();

            foreach(Transform child in painelCartasInterferencia){
                Destroy(child.gameObject);
            }

            botaoAjuda.onClick.RemoveAllListeners();
            botaoIgnorar.onClick.RemoveAllListeners();
            botaoAtrapalha.onClick.RemoveAllListeners();

            nomeJogador.text = jogador.Nome;
            cartasDeAumentaMonstro = jogador.Mao.NaMao.Where(c => c.Efeito != null && c.Efeito.GetType() == typeof(EfeitoAumentaMonstro)).ToList();

            botaoAjuda.onClick.AddListener(() => {
                ajudantes.Add(jogador);
                Debug.Log("Clicou na ajuda");
                botaoAjudaClick = true;
            });

            botaoIgnorar.onClick.AddListener(() => {
                Debug.Log(jogador.Nome + " escolheu ignorar");

                botaoIgnorarClick = true;
            });

            botaoAtrapalha.onClick.AddListener(() => {
                Debug.Log(jogador.Nome + " Clicou em atrapalhar");

                if(cartasDeAumentaMonstro.Count == 0){
                    Debug.Log("Você não possui cartas que aumentam monstro");
                    botaoIgnorarClick = true;

                } else{
                    Debug.Log("Cartas de aumenta monstro:");
                    foreach(Carta carta in cartasDeAumentaMonstro){
                        cartaDisplay.Atualiza(carta);

                        Transform cartaView = painelCartasInterferencia.Find(carta.Nome);
                        Button botaoCarta = cartaView.Find("BotaoCarta").GetComponent<Button>();
                        botaoCarta.onClick.AddListener(() => {
                            botaoCarta.onClick.RemoveAllListeners();
                            cartasInterferencia.Add(carta);
                            jogador.Mao.NaMao.Remove(carta);
                            Debug.Log("Carta adicionada: " + carta.Nome);
    
                            botaoAtrapalhaClick = true;
                        }); 
                    }
                }

            });

            yield return new WaitUntil(() => botaoAjudaClick || botaoAtrapalhaClick || botaoIgnorarClick);

            botaoAjudaClick = false;
            botaoAtrapalhaClick = false;
            botaoIgnorarClick = false;
            
            Debug.Log("FIM DO FOREACH: " + cartasDeAumentaMonstro.Count);
            cartasDeAumentaMonstro.Clear();
            cartasDeAumentaMonstro.TrimExcess();
        }
        menuInteracao.SetActive(false);
        onInteracaoCompleta?.Invoke();
    }

    public void IniciarEscolhaAjudante(Controle controle, Action<Jogador> onAjudanteSelecionado)
    {
        StartCoroutine(EscolherAjudante(controle, onAjudanteSelecionado));
    }

    public IEnumerator EscolherAjudante(Controle controle, Action<Jogador> onAjudanteSelecionado)
    {
        //recusou = false;
        Debug.Log("Numero de Ajudantes: " + ajudantes.Count);
        foreach(Transform child in listaAjudantesBox){
            Destroy(child.gameObject);
        }
        Debug.Log("Lista de botoes resetada");

        menuAjudantes.SetActive(true);
        foreach(Jogador ajudanteAtual in ajudantes){

            GameObject botaoAj = Instantiate(prefabAjudante, listaAjudantesBox);
            Button botao = botaoAj.GetComponent<Button>();
            TextMeshProUGUI textoBotao = botaoAj.GetComponentInChildren<TextMeshProUGUI>();
            
            textoBotao.text = $"{ajudanteAtual.Nome} - Nível: {ajudanteAtual.Nivel}, Poder: {ajudanteAtual.Bonus}";

            botao.onClick.AddListener(() => {
                Debug.Log("Ajudante escolhido: " + ajudanteAtual.Nome);
                ajudante = ajudanteAtual;
                menuAjudantes.SetActive(false);
                ajudantes.Clear();
                ajudantes.TrimExcess();
                onAjudanteSelecionado?.Invoke(ajudanteAtual);
            });
        }

        botaoRecusar.onClick.AddListener(() => {
            Debug.Log("Ajuda recusada");
            menuAjudantes.SetActive(false);
            ajudantes.Clear();
            ajudantes.TrimExcess();
            onAjudanteSelecionado?.Invoke(null);
        });

        yield return new WaitUntil(() => ajudante != null);
    }
      
}
