using UnityEngine;
using UnityEngine.UI;

public class EstadoEncrenca : EstadoJogo
{
    public override void IniciarEstado(Controle controle)
    {
        Carta c = controle.CartaJogo;
        // Lembra de remover a carta da mao do jogador la em EstadoPreparacao2 e entao remover o condicional
        if(c is CartaMonstro){
            c.EfeitoCompra(controle);
        }
    }

    public override void RunEstado(Controle controle)
    {

    }
}
