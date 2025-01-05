using UnityEngine;
using UnityEngine.UI;

public class EstadoSaquear : EstadoJogo
{
    private Button botaoCartaPorta;
    public override void IniciarEstado(Controle controle)
    {
        Debug.Log("Saqueando a Sala");
        //Debug.Log("Comprando Carta Porta");
        Carta c = controle.BaralhoPorta.CompraCarta();
        controle.JogadorAtual.Mao.Add(c);
        controle.TrocaEstado(EstadoFimTurno.CreateInstance<EstadoFimTurno>());
    }

    public override void RunEstado(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
