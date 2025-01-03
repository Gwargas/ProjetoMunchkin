using Unity.VisualScripting;
using UnityEngine;

public class EstadoFimTurno : EstadoJogo
{
    public override void IniciarEstado(Controle controle)
    {
        if(controle.JogadorAtual.Mao.NaMao.Count > 5){
            //fazer algo(descartar ou equipar/carregar)
        }
        controle.Turno++;
        if(controle.JogadorAtual.Morto == true)
        {
            controle.ReviveMorto(controle.JogadorAtual);
        }
        controle.JogadorAtual = controle.getJogadorAtual();
        controle.TrocaEstado(EstadoPreparacao.CreateInstance<EstadoPreparacao>());
    }

    public override void RunEstado(Controle controle)
    {
        
    }
}
