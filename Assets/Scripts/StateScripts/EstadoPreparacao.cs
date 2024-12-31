using UnityEngine;

public class EstadoPreparacao : EstadoJogo
{
    public override void IniciarEstado(Controle controle)
    {
        throw new System.NotImplementedException();
    }

    public override void RunEstado(Controle controle)
    {
        // Movimentacao de cartas pelo jogador

        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Jogador Comprou Carta");
            controle.TrocaEstado(new EstadoCompraPorta());
        }

    }
}
