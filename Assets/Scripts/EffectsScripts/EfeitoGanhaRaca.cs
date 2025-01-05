using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoGanhaRaca", menuName = "Scriptable Objects/EfeitoGanhaRaca")]
public class EfeitoGanhaRaca : Efeito
{
    public override void Apply(Controle controle) {
        controle.JogadorAtual.Raca = this.titulo;
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
