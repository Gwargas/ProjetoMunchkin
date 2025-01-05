using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoGanhaClasse", menuName = "Scriptable Objects/EfeitoGanhaClasse")]
public class EfeitoGanhaClasse : Efeito
{
    public override void Apply(Controle controle) {
        controle.JogadorAtual.Classe = this.titulo;
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
