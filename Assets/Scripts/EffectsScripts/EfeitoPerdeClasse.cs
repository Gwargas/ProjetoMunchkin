using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeClasse", menuName = "Scriptable Objects/EfeitoPerdeClasse")]
public class EfeitoPerdeClasse : Efeito
{
    public override void Apply(Controle controle) {
        Hand mao = controle.JogadorAtual.Mao;
        List<Carta> emUso = mao.EmUso;

        for (int i = 0; i < emUso.Count; i++) {
            if (emUso[i].GetType() == typeof(CartaClasse)) {
                if (emUso[i].Nome.ToLower() is not "nada") {
                    emUso.RemoveAt(i);
                    controle.JogadorAtual.Classe = "nada";
                    mao.EmUso = emUso;
                    controle.JogadorAtual.Mao = mao;
                    controle.DescartarCartaPorta((CartaPorta)emUso[i]);
                    break;
                }
            }
        }
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
