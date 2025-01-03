using UnityEngine;

[CreateAssetMenu(fileName = "CartaRaca", menuName = "Scriptable Objects/CartaRaca")]
public class CartaRaca : CartaPorta
{
    public override void EfeitoCompra(Controle controle)
    {
        Debug.Log("Comprou carta raça");
        controle.TrocaEstado(EstadoRacaClasse.CreateInstance<EstadoRacaClasse>());
    }
}
