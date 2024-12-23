using UnityEngine;

[CreateAssetMenu(fileName = "CartaMonstro", menuName = "Scriptable Objects/CartaMonstro")]
public class CartaMonstro : CartaPorta
{
    [SerializeField] private int nivel;

    public int Nivel
    {
        get => nivel;
        set => nivel = value;
    }

    public override void EfeitoCompra()
    {
        throw new System.NotImplementedException();
    }
}
