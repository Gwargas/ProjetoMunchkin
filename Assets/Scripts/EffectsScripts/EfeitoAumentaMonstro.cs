using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoAumentaMonstro", menuName = "Scriptable Objects/EfeitoAumentaMonstro")]
public class EfeitoAumentaMonstro : Efeito
{
    public EfeitoAumentaMonstro(string titulo, int[] descricao) : base(titulo, descricao) {}
    
    public override CartaMonstro Apply(CartaMonstro carta) {
        carta.Nivel += descricao[0];
        carta.Recompensa += descricao[1];
        return carta;
    }

    public override void Apply(Controle controle)
    {
        throw new System.NotImplementedException();
    }

    public override CartaMonstro Revert(CartaMonstro carta) {
        carta.Nivel -= descricao[0];
        carta.Recompensa -= descricao[1];
        return carta;
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
