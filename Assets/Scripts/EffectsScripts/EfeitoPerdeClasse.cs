using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeClasse", menuName = "Scriptable Objects/EfeitoPerdeClasse")]
public class EfeitoPerdeClasse : Efeito
{
    public override void Apply(Controle controle) {
        controle.JogadorAtual.Classe = "nada";
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
