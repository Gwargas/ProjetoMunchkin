using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoGanhaRaca", menuName = "Scriptable Objects/EfeitoGanhaRaca")]
public class EfeitoGanhaRaca : Efeito
{
    public override void Apply(Controle controle) {
        if (!controle.JogadorAtual.Raca.Equals("nada")) {
            List<Carta> emUso = controle.JogadorAtual.Mao.EmUso;
            for (int i = 0; i < emUso.Count; i++) {
                if (emUso[i].Nome.ToLower().Equals("halfling")
                    || emUso[i].Nome.ToLower().Equals("elfo")
                    || emUso[i].Nome.ToLower().Equals("anao")) {
                    controle.DescartarCartaPorta((CartaPorta)emUso[i]);
                    emUso.RemoveAt(i);
                    controle.JogadorAtual.Mao.EmUso = emUso;
                }
            }
        }
        controle.JogadorAtual.Raca = this.titulo;
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
