using UnityEngine;

[CreateAssetMenu(fileName = "EstadoCompraPorta", menuName = "Scriptable Objects/EstadoCompraPorta")]
public class EstadoCompraPorta : EstadoJogo
{
    
    public override void IniciarEstado(Controle controle)
    {
        Debug.Log("Comprando carta porta");
        /*
        Carta c = controle.BaralhoPorta.CompraCarta();
        controle.CartaJogo = c;
        controle.CartaJogo.EfeitoCompra(controle);
        */
    }

    public override void RunEstado(Controle controle)
    {
        //Debug.Log("Verificando Qual Carta foi comprada");

        if(Input.GetKeyDown(KeyCode.A)){
            /*Interferencia inter = GameObject.FindObjectOfType<Interferencia>();
            if (inter != null){
                Debug.Log("funcionou");
            }*/
            //EstadoCombate estadoCombate = new EstadoCombate();
            //estadoCombate.MenuInterferencia = inter.MenuInteracao;
            controle.TrocaEstado(new EstadoCombate());
        }
    }
}
