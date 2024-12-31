using UnityEngine;

[CreateAssetMenu(fileName = "CartaEquipamento", menuName = "Scriptable Objects/CartaEquipamento")]
public class CartaEquipamento : CartaTesouro
{
    [SerializeField] private int ehGrande;
    [SerializeField] private string parteCorpo;
    [SerializeField] private string limitacaoRaca; 
    [SerializeField] private string limitacaoClasse;

    public bool condicaoUso(){
        throw new System.NotImplementedException();
        // (Note: David) Lógica de uso 
    } 

    public override void EfeitoCompra()
    {
        throw new System.NotImplementedException();
    }
}
