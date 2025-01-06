using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using System;

public class CenaFinalDisplay : MonoBehaviour {

    [SerializeField] public RectTransform tela;
    private Controle controle;
    private Jogador jogador;

    public void Start() {
        jogador = GameSettings.vencedor;
        if (jogador != null){
            Debug.Log("Vencedor encontrado");
        }
    }

    public void Atualiza() {

        GameObject vencedor = GameObject.Find("Canvas");
        vencedor.transform.Find("Nome").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = jogador.Nome;
        
        Sprite imagem = Resources.Load<Sprite>($"CartaPerfil/{jogador.Classe.ToLower()}");
        vencedor.transform.Find("Jogador").Find("Imagem").GetComponent<UnityEngine.UI.Image>().sprite = imagem;
    }

    public void OnButtonClick() {
        SceneManager.LoadScene("MenuInicial");
    }
}