using UnityEngine;
using UnityEngine.UI;

public class EstadoPreparacao : EstadoJogo
{
    private Button botaoCartaPorta;
    public override void IniciarEstado(Controle controle)
    {
        botaoCartaPorta = GameObject.Find("BotaoComprarCartaPorta")?.GetComponent<Button>();
        botaoCartaPorta.onClick.AddListener(() => {
            Debug.Log("Botão Clicado");
            controle.TrocaEstado(new EstadoCompraPorta());
        });
    }

    public override void RunEstado(Controle controle)
    {
        // Movimentacao de cartas pelo jogador
    }
}
