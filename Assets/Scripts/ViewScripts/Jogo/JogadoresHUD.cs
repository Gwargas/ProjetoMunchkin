using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class JogadoresHUD : MonoBehaviour {

    public GameObject jogadorPrincipalModelo; 
    public GameObject jogadorSecundarioModelo; 
    [SerializeField] public RectTransform areaJogadorPrincipal;
    [SerializeField] public RectTransform areaJogadoresSecundarios;

    public void Atualiza(Controle controle) {

        // apagando area de jogadores antiga
        foreach (Transform child in areaJogadoresSecundarios) {
            Destroy(child.gameObject);
        }
        // apagando area de jogadores antiga
        foreach (Transform child in areaJogadorPrincipal) {
            Destroy(child.gameObject);
        }
        
        Jogador jogadorPrincipal = controle.JogadorAtual;
        List<Jogador> jogadores = controle.Jogadores;

        foreach (Jogador jogador in jogadores) {
            GameObject jogadorObject;
            
            if (jogador.Nome == jogadorPrincipal.Nome) {
                jogadorObject = Instantiate(jogadorPrincipalModelo, areaJogadorPrincipal);
            } else {
                jogadorObject = Instantiate(jogadorSecundarioModelo, areaJogadoresSecundarios);
            }

            Sprite raca = Resources.Load<Sprite>($"CartaPerfil/{jogador.Raca.ToLower()}");
            jogadorObject.transform.Find("JogadorImagem").GetComponent<UnityEngine.UI.Image>().sprite = raca;

            if (jogador.Classe == "nada") {
                jogadorObject.transform.Find("Badge").GetComponent<UnityEngine.UI.Image>().enabled = false;
                jogadorObject.transform.Find("Badge").Find("Classe").GetComponent<UnityEngine.UI.Image>().enabled = false;
            } else {
                Sprite classe = Resources.Load<Sprite>($"CartaPerfil/{jogador.Classe.ToLower()}");
                jogadorObject.transform.Find("Badge").Find("Classe").GetComponent<UnityEngine.UI.Image>().sprite = classe;
            }

            jogadorObject.transform.Find("JogadorNome").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = jogador.Nome;

            jogadorObject.transform.Find("JogadorNivel").Find("Nivel").GetComponent<TextMeshProUGUI>().text = jogador.Nivel.ToString();
            jogadorObject.transform.Find("JogadorBonus").Find("Bonus").GetComponent<TextMeshProUGUI>().text = jogador.Bonus.ToString();
            jogadorObject.transform.name = jogador.Nome;
        }
    }
}