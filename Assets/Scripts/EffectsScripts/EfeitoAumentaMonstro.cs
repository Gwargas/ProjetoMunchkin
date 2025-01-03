using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoAumentaMonstro", menuName = "Scriptable Objects/EfeitoAumentaMonstro")]
public class EfeitoAumentaMonstro : Efeito
{
    public override void Apply(Controle controle)
    {
        CartaMonstro carta = controle.CartaJogo as CartaMonstro;
        carta.Nivel += descricao[0];
        carta.Recompensa += descricao[1];
    }
    
    public override void Revert(Controle controle)
    {
        CartaMonstro carta = controle.CartaJogo as CartaMonstro;
        carta.Nivel -= descricao[0];
        carta.Recompensa -= descricao[1];
    }
}
