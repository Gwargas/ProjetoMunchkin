using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeClasse", menuName = "Scriptable Objects/EfeitoPerdeClasse")]
public class EfeitoPerdeClasse : Efeito
{
    public EfeitoPerdeClasse(string titulo, int[] descricao) : base(titulo, descricao)
    {
    }
    public override void Apply(Controle controle) {
        controle.JogadorAtual.Classe = "nada";
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
