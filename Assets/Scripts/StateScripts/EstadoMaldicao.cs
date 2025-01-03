using UnityEngine;

[CreateAssetMenu(fileName = "EstadoMaldicao", menuName = "Scriptable Objects/EstadoMaldicao")]
public class EstadoMaldicao : EstadoJogo
{
    public override void IniciarEstado(Controle controle)
    {
        //controle.CartaJogo.
    }

    public override void RunEstado(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
