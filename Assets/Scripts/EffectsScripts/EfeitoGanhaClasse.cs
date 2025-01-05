using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoGanhaClasse", menuName = "Scriptable Objects/EfeitoGanhaClasse")]
public class EfeitoGanhaClasse : Efeito
{
    public override void Apply(Controle controle) {

        if (!controle.JogadorAtual.Classe.Equals("humano")) {
            List<Carta> emUso = controle.JogadorAtual.Mao.EmUso;

            for (int i = 0; i < emUso.Count; i++) {
                if (emUso[i].Nome.ToLower().Equals("guerreiro")
                    || emUso[i].Nome.ToLower().Equals("clerigo")
                    || emUso[i].Nome.ToLower().Equals("mago")) {
                    controle.DescartarCartaPorta((CartaPorta)emUso[i]);
                    emUso.RemoveAt(i);
                    controle.JogadorAtual.Mao.EmUso = emUso;
                }
            }
        }
        controle.JogadorAtual.Classe = this.titulo;
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
