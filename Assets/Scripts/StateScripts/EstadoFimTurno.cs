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
        controle.JogadorAtual = controle.Jogadores[controle.Turno % controle.Jogadores.Count];
        controle.TrocaEstado(new EstadoPreparacao());
    }

    public override void RunEstado(Controle controle)
    {
        
    }
}
