using UnityEngine;

[CreateAssetMenu(fileName = "CartaMaldição", menuName = "Scriptable Objects/CartaMaldição")]
public class CartaMaldição : CartaPorta
{
    //[SerializeField] private Jogador vitima;
    
    public override void EfeitoCompra(Controle controle)
    {
        controle.TrocaEstado(EstadoMaldicao.CreateInstance<EstadoMaldicao>());
    }
}
