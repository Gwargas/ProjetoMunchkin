using UnityEngine;

[CreateAssetMenu(fileName = "CartaClasse", menuName = "Scriptable Objects/CartaClasse")]
public class CartaClasse : CartaPorta
{
    public CartaClasse(string nome, string descricao, Efeito efeito, string imagem) : base(nome, descricao, efeito, imagem)
    {
    }
    public override void EfeitoCompra(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
