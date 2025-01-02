using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class CartaExibe : MonoBehaviour
{
    [SerializeField] private Image fundo; 
    [SerializeField] private Image imagem; 
    [SerializeField] private TextMeshProUGUI titulo; // Referência ao título
    [SerializeField] private TextMeshProUGUI descricao; // Referência à descrição

    [SerializeField] private Image carta; 

    // Método para configurar a carta
    public void Exibe(string novaImagem, string novoTitulo, string novaDescricao) {
        imagem.sprite = Sprite.Create(
            Resources.Load<Texture2D>(novaImagem), 
            new Rect(0, 0, 100, 100), 
            new Vector2(0.5f, 0.5f)
        );
        titulo.text = novoTitulo;
        descricao.text = novaDescricao;
    }
}
