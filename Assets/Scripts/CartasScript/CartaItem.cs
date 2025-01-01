using UnityEngine;

[CreateAssetMenu(fileName = "CartaItem", menuName = "Scriptable Objects/CartaItem")]
public class CartaItem : CartaTesouro
{
    public CartaItem(string nome, string descricao, Efeito efeito, string imagem, int preco, int bonus) : base(nome, descricao, efeito, imagem, preco, bonus)
    {
    }
    public override void EfeitoCompra(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
