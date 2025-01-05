using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class CenaFinalDisplay : MonoBehaviour {

    [SerializeField] public RectTransform tela;
    private Controle controle;
    private Jogador jogador;

    public void Start() {
        controle = GameObject.Find("GameManager").GetComponent<GameManager>().controle;
    }

    public void Atualiza() {
        jogador = controle.JogadorAtual;

        GameObject vencedor = GameObject.Find("Canvas");
        vencedor.transform.Find("Jogador").Find("Titulo").GetComponent<TextMeshProUGUI>().text = jogador.Nome;
        
        Sprite imagem = Resources.Load<Sprite>($"CartaPerfil/{jogador.Classe.ToLower()}");
        vencedor.transform.Find("Jogador").Find("Imagem").GetComponent<UnityEngine.UI.Image>().sprite = imagem;
    }

    public void OnButtonClick() {
        SceneManager.LoadScene("MenuInicial");
    }
}