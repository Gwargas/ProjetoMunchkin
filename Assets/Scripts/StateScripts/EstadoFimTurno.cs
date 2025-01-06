using Unity.VisualScripting;
using UnityEngine;

public class EstadoFimTurno : EstadoJogo
{
    private bool fim = false;
    public override void IniciarEstado(Controle controle)
    {
        /*
        Debug.Log("Tenha no max 5 cartas!");//debug teste
        controle.Turno++;
        if(controle.JogadorAtual.Morto == true)
        {
            Debug.Log("Revivendo" + controle.JogadorAtual.Nome);
            controle.ReviveMorto(controle.JogadorAtual);
        }
        Debug.Log("Fim do Turno de: " + controle.JogadorAtual.Nome);
        controle.JogadorAtual = controle.getJogadorAtual();
        controle.TrocaEstado(EstadoPreparacao.CreateInstance<EstadoPreparacao>());
        //}
        //else{
            //controle.TrocaEstado(EstadoFimTurno.CreateInstance<EstadoFimTurno>());//calma
        //}*/
    }

    public override void RunEstado(Controle controle)
    {
        if(controle.JogadorAtual.Mao.NaMao.Count <= 5)
        {    
            fim = true;    
        }

        if(fim)
        {
            controle.Turno++;
            if(controle.JogadorAtual.Morto == true)
            {
            Debug.Log("Revivendo" + controle.JogadorAtual.Nome);
            controle.ReviveMorto(controle.JogadorAtual);
            }
            Debug.Log("Fim do Turno de: " + controle.JogadorAtual.Nome);
            controle.JogadorAtual = controle.getJogadorAtual();
            controle.TrocaEstado(EstadoPreparacao.CreateInstance<EstadoPreparacao>());
        }
    
    }
}
