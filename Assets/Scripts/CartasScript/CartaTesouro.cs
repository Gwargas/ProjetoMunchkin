using UnityEngine;

public abstract class CartaTesouro : Carta
{
    [SerializeField] private int preco;

    public override abstract void EfeitoCompra(Controle controle);
}
