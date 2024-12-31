using System.Collections.Generic;
using UnityEngine;

public class EstadoCombate : EstadoJogo
{
    private List<Jogador> ajudantes = new List<Jogador>();
    private int interferenciaMonstro = 0;
    private int interferenciaJogador = 0;
    
    public override void IniciarEstado(Controle controle)
    {
        controle.Interferir();
    }

    public override void RunEstado(Controle controle)
    {
        
        Debug.Log("Tratando Combate");
    }
}
