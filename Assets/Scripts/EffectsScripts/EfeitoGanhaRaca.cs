using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoGanhaRaca", menuName = "Scriptable Objects/EfeitoGanhaRaca")]
public class EfeitoGanhaRaca : Efeito
{
    public override void Apply(Controle controle) {
        if (!controle.JogadorAtual.Raca.Equals("nada")) {
            List<Carta> emUso = controle.JogadorAtual.Mao.EmUso;
            for (int i = 0; i < emUso.Count; i++) {
                if (emUso[i].GetType() == typeof(CartaRaca)) {
                    emUso.RemoveAt(i);
                    controle.JogadorAtual.Mao.EmUso = emUso;
                    controle.JogadorAtual.Mao.NaMao.Add(emUso[i]);
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
