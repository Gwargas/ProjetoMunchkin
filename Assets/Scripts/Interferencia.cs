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

    public GameObject MenuInteracao
    {
        get => menuInteracao;
    }

    public void IniciarInteracao(Controle controle)
    {
        StartCoroutine(Interferir(controle));
    }

    public IEnumerator Interferir(Controle controle)
    {
        Debug.Log("Iniciou o metodo");
        List<Jogador> jogadoresRestantes = controle.Jogadores.Where(j => j != controle.JogadorAtual).ToList();
        //Debug.Log("Jogadores Restantes: " + jogadoresRestantes.Count);
        menuInteracao.SetActive(true);
        bool botaoAjudaClick = false;
        bool botaoAtrapalhaClick = false;
        Debug.Log("antes do foreach");
        foreach(Jogador jogador in jogadoresRestantes){
            nomeJogador.text = jogador.Nome;

            botaoAjuda.onClick.RemoveAllListeners();
            botaoAtrapalha.onClick.RemoveAllListeners();

            botaoAjuda.onClick.AddListener(() => {
                Debug.Log("Clicou na ajuda");
                botaoAjudaClick = true;
            });

            botaoAtrapalha.onClick.AddListener(() => {
                Debug.Log("Clicou em atrapalhar");
                botaoAtrapalhaClick = true;
            });
            Debug.Log("Antes do wait");
            yield return new WaitUntil(() => botaoAjudaClick || botaoAtrapalhaClick);

            botaoAjudaClick = false;
            botaoAtrapalhaClick = false;
            Debug.Log("Fim da primeira Iteracao");
        }
        Debug.Log("Terminou o loop");
        menuInteracao.SetActive(false);
    }
}
