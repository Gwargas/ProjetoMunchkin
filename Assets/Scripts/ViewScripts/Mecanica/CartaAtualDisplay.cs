using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Linq.Expressions;
using UnityEngine.UI;
using Unity.VisualScripting;

public class CartaAtualDisplay : MonoBehaviour {
 
    [SerializeField] private CartaDisplay cartaDisplay;
    private Controle controle;

    private void Start(){
        controle = GameObject.Find("GameManager").GetComponent<GameManager>().controle;
        cartaDisplay = GameObject.Find("AreaCombate").GetComponent<CartaDisplay>();
    }

    public void Atualiza() {
        Carta carta = controle.CartaJogo;

        GameObject cartaObject = GameObject.Find("CartaJogo");

        cartaObject.transform.Find("Titulo").GetComponent<TextMeshProUGUI>().text = carta.Nome;
        
        Sprite imagem = Resources.Load<Sprite>($"CartaPerfil/{carta.CartaPath}");
        cartaObject.transform.Find("Imagem").GetComponent<UnityEngine.UI.Image>().sprite = imagem;
        cartaObject.transform.Find("Imagem").GetComponent<UnityEngine.UI.Image>().preserveAspect = true;

        cartaObject.transform.Find("Descricao").GetComponent<TextMeshProUGUI>().text = carta.Descricao;

        if (carta.GetType() == typeof(CartaMonstro)) {
            CartaMonstro cartaMonstro = carta as CartaMonstro;
            cartaObject.transform.Find("Nivel").GetComponent<TextMeshProUGUI>().text = $"{cartaMonstro.NiveisAGanhar.ToString()} em nivel";
            cartaObject.transform.Find("Tesouro").GetComponent<TextMeshProUGUI>().enabled = false;
            
        } else if (carta.GetType() == typeof(CartaEquipamento) || carta.GetType() == typeof(CartaItem)) {
            CartaTesouro cartaTesouro = carta as CartaTesouro;
            cartaObject.transform.Find("Tesouro").GetComponent<TextMeshProUGUI>().text = $"{cartaTesouro.Preco.ToString()} em tesouro";
            cartaObject.transform.Find("Nivel").GetComponent<TextMeshProUGUI>().enabled = false;

        } else {
            cartaObject.transform.Find("Nivel").GetComponent<TextMeshProUGUI>().enabled = false;
            cartaObject.transform.Find("Tesouro").GetComponent<TextMeshProUGUI>().enabled = false;
        }

        cartaObject.name = carta.Nome;
    }
}