using UnityEngine;

[CreateAssetMenu(fileName = "CartaRaca", menuName = "Scriptable Objects/CartaRaca")]
public class CartaRaca : CartaPorta
{
    public CartaRaca(string nome, string descricao, Efeito efeito, string imagem) : base(nome, descricao, efeito, imagem)
    {
    }
    public override void EfeitoCompra(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
