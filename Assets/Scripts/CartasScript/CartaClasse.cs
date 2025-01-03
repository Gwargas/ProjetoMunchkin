using UnityEngine;

[CreateAssetMenu(fileName = "CartaClasse", menuName = "Scriptable Objects/CartaClasse")]
public class CartaClasse : CartaPorta {

    public override void EfeitoCompra(Controle controle)
    {
        Debug.Log("Comprou carta classe");
        controle.TrocaEstado(EstadoRacaClasse.CreateInstance<EstadoRacaClasse>());
    }
}
