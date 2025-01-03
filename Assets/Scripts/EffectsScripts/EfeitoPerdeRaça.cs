using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeRaça", menuName = "Scriptable Objects/EfeitoPerdeRaça")]
public class EfeitoPerdeRaça : Efeito
{
    public override void Apply(Controle controle) {
        controle.JogadorAtual.Raca = "humano";
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
