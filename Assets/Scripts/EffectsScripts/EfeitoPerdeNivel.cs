using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeNivel", menuName = "Scriptable Objects/EfeitoPerdeNivel")]
public class EfeitoPerdeNivel : Efeito
{
    public EfeitoPerdeNivel(string titulo, int[] atributos) : base(titulo, atributos)
    {
    }
    public override void Apply(Controle controle) {
        if (controle.JogadorAtual.Nivel - descricao[0] < 1) {
            controle.JogadorAtual.Nivel = 1;
            return;
        } else {
            controle.JogadorAtual.Nivel -= descricao[0];
        }
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
