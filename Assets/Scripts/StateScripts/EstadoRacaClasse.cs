using UnityEngine;

[CreateAssetMenu(fileName = "EstadoAcao", menuName = "Scriptable Objects/EstadoAcao")]
public class EstadoRacaClasse : EstadoJogo
{
    public override void IniciarEstado(Controle controle)
    {
        controle.JogadorAtual.Mao.Add(controle.CartaJogo);
        Debug.Log("Carta Raca/Classe adicionada a mão");
        controle.TrocaEstado(EstadoPreparacao2.CreateInstance<EstadoPreparacao2>());
    }

    public override void RunEstado(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
