using UnityEngine;
using UnityEngine.UI;

public class EstadoSaquear : EstadoJogo
{
    private Button botaoCartaPorta;
    public override void IniciarEstado(Controle controle)
    {
        botaoCartaPorta.onClick.AddListener(() => {
            Debug.Log("Botão Clicado");
            Carta c = controle.BaralhoPorta.CompraCarta();
            controle.JogadorAtual.Mao.Add(c);
            controle.TrocaEstado(EstadoFimTurno.CreateInstance<EstadoFimTurno>());
        });
    }

    public override void RunEstado(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
