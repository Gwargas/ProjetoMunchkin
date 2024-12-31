using UnityEngine;

public abstract class CartaTesouro : Carta
{
    [SerializeField] private int preco;
    [SerializeField] private int bonus;

    public override abstract void EfeitoCompra(Controle controle);
}
