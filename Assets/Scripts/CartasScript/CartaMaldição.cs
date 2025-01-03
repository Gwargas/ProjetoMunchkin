using UnityEngine;

[CreateAssetMenu(fileName = "CartaMaldição", menuName = "Scriptable Objects/CartaMaldição")]
public class CartaMaldição : CartaPorta
{
    //[SerializeField] private Jogador vitima;
    
    public override void EfeitoCompra(Controle controle)
    {
        Debug.Log("Comprou carta maldição");
        controle.TrocaEstado(EstadoMaldicao.CreateInstance<EstadoMaldicao>());
    }
}
