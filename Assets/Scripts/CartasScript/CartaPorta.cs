using UnityEngine;

public abstract class CartaPorta : Carta
{
    public void Inicializa(string nome, string descricao, Efeito efeito, string imagem)
    {
        this.Nome = nome;
        this.Descricao = descricao;
        this.Efeito = efeito;
        this.CartaPath = imagem;
    }
    
    public override abstract void EfeitoCompra(Controle controle);
}
