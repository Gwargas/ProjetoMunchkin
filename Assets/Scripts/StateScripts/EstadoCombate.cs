using UnityEngine;

public class EstadoCombate : EstadoJogo
{
    public override void IniciarEstado(Controle controle)
    {
        throw new System.NotImplementedException();
    }

    public override void RunEstado(Controle controle)
    {
        Debug.Log("Tratando Combate");
    }
}
