using UnityEngine;

[CreateAssetMenu(fileName = "CartaClasse", menuName = "Scriptable Objects/CartaClasse")]
public class CartaClasse : CartaPorta {

    public override void EfeitoCompra(Controle controle)
    {
        controle.TrocaEstado(new EstadoRacaClasse());
    }
}
