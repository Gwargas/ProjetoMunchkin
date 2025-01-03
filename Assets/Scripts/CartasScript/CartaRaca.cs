using UnityEngine;

[CreateAssetMenu(fileName = "CartaRaca", menuName = "Scriptable Objects/CartaRaca")]
public class CartaRaca : CartaPorta
{
    public override void EfeitoCompra(Controle controle)
    {
        controle.TrocaEstado(EstadoRacaClasse.CreateInstance<EstadoRacaClasse>());
    }
}
