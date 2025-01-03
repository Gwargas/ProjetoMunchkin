using UnityEngine;

[CreateAssetMenu(fileName = "EstadoAcao", menuName = "Scriptable Objects/EstadoAcao")]
public class EstadoAcao : EstadoJogo
{
    public override void IniciarEstado(Controle controle)
    {
        controle.JogadorAtual.Mao.Add(controle.CartaJogo);
    }

    public override void RunEstado(Controle controle)
    {
        // tratar as proximas possíveis interacoes, como arrumar encrenca ou saquear a sala.
        throw new System.NotImplementedException();
    }
}
