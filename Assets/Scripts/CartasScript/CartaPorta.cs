using UnityEngine;

public abstract class CartaPorta : Carta
{
    protected CartaPorta(string nome, string descricao, Efeito efeito, string cartaPath) : base(nome, descricao, efeito, cartaPath)
    {
    }

    public override abstract void EfeitoCompra(Controle controle);
}
