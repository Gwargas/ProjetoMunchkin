using UnityEngine;

[CreateAssetMenu(fileName = "EstadoMaldicao", menuName = "Scriptable Objects/EstadoMaldicao")]
public class EstadoMaldicao : EstadoJogo
{
    public override void IniciarEstado(Controle controle)
    {
        Carta c = controle.CartaJogo;
        Efeito efeito = c.Efeito;
        efeito.Apply(controle);
        controle.TrocaEstado(EstadoPreparacao2.CreateInstance<EstadoPreparacao2>());
    }

    public override void RunEstado(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
