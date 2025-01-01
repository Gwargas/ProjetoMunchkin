using UnityEngine;

public abstract class CartaTesouro : Carta
{
    [SerializeField] private int preco;
    [SerializeField] private int bonus;

    public CartaTesouro(string nome, string descricao, Efeito efeito, string imagem, int preco, int bonus) : base(nome, descricao, efeito, imagem)
    {
        this.preco = preco;
        this.bonus = bonus;
    }

    public override abstract void EfeitoCompra(Controle controle);
}
