using UnityEngine;

[CreateAssetMenu(fileName = "CartaItem", menuName = "Scriptable Objects/CartaItem")]
public class CartaItem : CartaTesouro
{
    // construtor
    public void Inicializa(string nome, string descricao, Efeito efeito, string imagem, int preco){
        this.Nome = nome;
        this.Descricao = descricao;
        this.Efeito = efeito;
        this.CartaPath = imagem;
        this.Preco = preco;
    }
    
    public override void EfeitoCompra(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
