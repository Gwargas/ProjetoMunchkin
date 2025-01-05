using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoGanhaBonus", menuName = "Scriptable Objects/EfeitoGanhaBonus")]
public class EfeitoGanhaBonus : Efeito
{
  
    public override void Apply(Controle controle) {
        controle.JogadorAtual.Bonus += descricao[0];
    }

    public override void Revert(Controle controle) {
        if (controle.JogadorAtual.Bonus - descricao[0] < 0) {
            controle.JogadorAtual.Nivel = 0;
        } else {
            controle.JogadorAtual.Bonus -= descricao[0];
        }
    }
}
