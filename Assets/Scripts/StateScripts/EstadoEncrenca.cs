using UnityEngine;
using UnityEngine.UI;

public class EstadoEncrenca : EstadoJogo
{
    public override void IniciarEstado(Controle controle)
    {
        Debug.Log("Arrumando encrenca");
        Carta c = controle.CartaJogo;
        // Lembra de remover a carta da mão do jogador (EstadoPreparacao2) e então remover o condicional.
        if(c is CartaMonstro){
            c.EfeitoCompra(controle);
        }
    }

    public override void RunEstado(Controle controle)
    {

    }
}
