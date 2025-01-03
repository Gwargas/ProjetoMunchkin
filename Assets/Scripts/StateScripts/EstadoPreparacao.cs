using UnityEngine;
using UnityEngine.UI;

public class EstadoPreparacao : EstadoJogo
{
    private Button botaoCartaPorta;
    public override void IniciarEstado(Controle controle)
    {
        Debug.Log("Turno de: " + controle.JogadorAtual.Nome);
        botaoCartaPorta = GameObject.Find("BotaoCartaPorta")?.GetComponent<Button>();
        botaoCartaPorta.onClick.RemoveAllListeners();
        botaoCartaPorta.onClick.AddListener(() => {
            Debug.Log("Botão Clicado");
            controle.TrocaEstado(EstadoCompraPorta.CreateInstance<EstadoCompraPorta>());
        });
    }

    public override void RunEstado(Controle controle)
    {
        // Movimentacao de cartas pelo jogador
        //Depende da funcao de equipar/desequipar cartas

    }
}
