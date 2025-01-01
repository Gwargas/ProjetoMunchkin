using UnityEngine;

[CreateAssetMenu(fileName = "CartaMaldição", menuName = "Scriptable Objects/CartaMaldição")]
public class CartaMaldição : CartaPorta
{
    //[SerializeField] private Jogador vitima;

    public CartaMaldição(string nome, string descricao, Efeito efeito, string imagem) : base(nome, descricao, efeito, imagem)
    {
    }
    
    public override void EfeitoCompra(Controle controle)
    {
        controle.TrocaEstado(new EstadoMaldicao());
    }
}
