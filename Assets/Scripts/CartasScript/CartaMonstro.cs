using UnityEngine;

[CreateAssetMenu(fileName = "CartaMonstro", menuName = "Scriptable Objects/CartaMonstro")]
public class CartaMonstro : CartaPorta
{
    [SerializeField] private int nivel;
    [SerializeField] private int niveisAGanhar;
    [SerializeField] private int recompensa;

    public int Nivel
    {
        get => nivel;
        set => nivel = value;
    }

    public int NiveisAGanhar
    {
        get => niveisAGanhar;
        set => niveisAGanhar = value;
    }

    public int Recompensa
    {
        get => recompensa;
        set => recompensa = value;
    }

    public override void EfeitoCompra()
    {
        throw new System.NotImplementedException();
    }
}
