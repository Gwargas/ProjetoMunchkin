using UnityEngine;

public abstract class CartaTesouro : Carta
{
    [SerializeField] private int preco;

    public override abstract void EfeitoCompra(Controle controle);

    public int Preco {
        get => preco;
        set => preco = value;
    }
}
