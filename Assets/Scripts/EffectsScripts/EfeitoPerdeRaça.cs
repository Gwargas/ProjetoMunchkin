using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeRaça", menuName = "Scriptable Objects/EfeitoPerdeRaça")]
public class EfeitoPerdeRaça : Efeito
{
    public EfeitoPerdeRaça(string titulo, int[] atributos) : base(titulo, atributos)
    {
    }
    public override void Apply(Controle controle) {
        controle.JogadorAtual.Raca = "humano";
    }

    public override CartaMonstro Apply(CartaMonstro carta)
    {
        throw new System.NotImplementedException();
    }

    public override CartaMonstro Revert(CartaMonstro carta)
    {
        throw new System.NotImplementedException();
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
