using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoGanhaRaca", menuName = "Scriptable Objects/EfeitoGanhaRaca")]
public class EfeitoGanhaRaca : Efeito
{
    public override void Apply(Controle controle) {
        if (!controle.JogadorAtual.Raca.Equals("nada")) {
            List<Carta> emUso = controle.JogadorAtual.Mao.EmUso;
            
            for (int i = 0; i < emUso.Count; i++) {
                if (emUso[i].GetType() == typeof(CartaRaca) && !emUso[i].Nome.ToLower().Equals(this.titulo.ToLower())) {
                    controle.DescartarCartaPorta(emUso[i] as CartaPorta);
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
