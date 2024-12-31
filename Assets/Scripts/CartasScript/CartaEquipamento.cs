using UnityEngine;

[CreateAssetMenu(fileName = "CartaEquipamento", menuName = "Scriptable Objects/CartaEquipamento")]
public class CartaEquipamento : CartaTesouro
{
    [SerializedField] private int ehGrande;
    [SerializedField] private string parteCorpo;
    [SerializedField] private string limitacaoRaca; 
    [SerializedField] private string limitacaoClasse;

    public bool condicaoUso(){
        // (Note: David) Lógica de uso 
    } 

    public override void EfeitoCompra()
    {
        throw new System.NotImplementedException();
    }
}
