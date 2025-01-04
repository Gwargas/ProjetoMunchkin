using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

public class CartaDisplay : MonoBehaviour {

    public GameObject cartaModelo; 
    [SerializeField] public RectTransform areaCartas;

    public void Atualiza(Carta carta) {

        GameObject cartaObject = Instantiate(cartaModelo, areaCartas);

        cartaObject.transform.Find("Titulo").GetComponent<TextMeshProUGUI>().text = carta.Nome;
        
        Sprite imagem = Resources.Load<Sprite>($"CartaPerfil/{carta.CartaPath}");
        cartaObject.transform.Find("Imagem").GetComponent<UnityEngine.UI.Image>().sprite = imagem;

        cartaObject.transform.Find("Descricao").GetComponent<TextMeshProUGUI>().text = carta.Descricao;

        if (carta.GetType() == typeof(CartaMonstro)) {
            CartaMonstro cartaMonstro = carta as CartaMonstro;
            cartaObject.transform.Find("Nivel").GetComponent<TextMeshProUGUI>().text = $"{cartaMonstro.NiveisAGanhar.ToString()} em nivel";
        } else {
            cartaObject.transform.Find("Nivel").GetComponent<TextMeshProUGUI>().enabled = false;
        }

        if (carta.GetType() == typeof(CartaTesouro)) {
            CartaTesouro cartaTesouro = carta as CartaTesouro;
            cartaObject.transform.Find("Tesouro").GetComponent<TextMeshProUGUI>().text = $"{cartaTesouro.Preco.ToString()} em tesouro";
        } else {
            cartaObject.transform.Find("Tesouro").GetComponent<TextMeshProUGUI>().enabled = false;
        }

        cartaObject.name = carta.Nome;
    }
}