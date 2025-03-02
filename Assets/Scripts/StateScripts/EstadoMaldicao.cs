using UnityEngine;

[CreateAssetMenu(fileName = "EstadoMaldicao", menuName = "Scriptable Objects/EstadoMaldicao")]
public class EstadoMaldicao : EstadoJogo
{
    public override void IniciarEstado(Controle controle)
    {
        Carta c = controle.CartaJogo;
        Efeito efeito = c.Efeito;

        if (efeito.GetType() != typeof(EfeitoAumentaMonstro)) {
            Debug.Log("Efeito não é de aumento de monstro");
            efeito.Apply(controle);
            Debug.Log("Maldição aplicada");
            controle.DescartarCartaPorta(c as CartaPorta);
            //controle.CartaJogo = null;
            Debug.Log("Maldição descartada");
            controle.TrocaEstado(EstadoPreparacao2.CreateInstance<EstadoPreparacao2>());
        }
        else{
            Debug.Log("Efeito é de aumento de monstro");
            controle.DescartarCartaPorta(c as CartaPorta);
            //controle.CartaJogo = null;
            Debug.Log("Maldição descartada");
            controle.TrocaEstado(EstadoPreparacao2.CreateInstance<EstadoPreparacao2>());
        }
        
    }

    public override void RunEstado(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
