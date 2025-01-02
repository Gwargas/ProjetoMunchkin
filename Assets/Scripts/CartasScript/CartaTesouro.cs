using UnityEngine;

public abstract class CartaTesouro : Carta
{
    [SerializeField] private int preco;

    public CartaTesouro(string nome, string descricao, Efeito efeito, string imagem, int preco) : base(nome, descricao, efeito, imagem)
    {
        this.preco = preco;
    }

    public override abstract void EfeitoCompra(Controle controle);
}
