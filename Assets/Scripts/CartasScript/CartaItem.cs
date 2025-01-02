using UnityEngine;

[CreateAssetMenu(fileName = "CartaItem", menuName = "Scriptable Objects/CartaItem")]
public class CartaItem : CartaTesouro
{
    public CartaItem(string nome, string descricao, Efeito efeito, string imagem, int preco) : base(nome, descricao, efeito, imagem, preco)
    {
    }
    public override void EfeitoCompra(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
