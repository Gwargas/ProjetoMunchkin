using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using System;

public class CenaFinalDisplay : MonoBehaviour {

    [SerializeField] public GameObject vencedor;
    private Jogador jogador;

    public void Start() {
        jogador = GameSettings.vencedor;
        if (jogador != null){
            Debug.Log("Vencedor encontrado");
        }
        Atualiza();
    }

    public void Atualiza() {
        vencedor.transform.Find("Nome").Find("Texto").GetComponent<TextMeshProUGUI>().text = jogador.Nome;
        Sprite imagem = Resources.Load<Sprite>($"CartaPerfil/{jogador.Raca.ToLower()}");
        vencedor.transform.Find("Imagem").GetComponent<UnityEngine.UI.Image>().sprite = imagem;
    }

    public void OnButtonClick() {
        SceneManager.LoadScene("MenuInicial");
    }
}