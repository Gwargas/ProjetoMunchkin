using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeClasse", menuName = "Scriptable Objects/EfeitoPerdeClasse")]
public class EfeitoPerdeClasse : Efeito
{
    public override void Apply(Controle controle) {
        Hand mao = controle.JogadorAtual.Mao;
        List<Carta> emUso = mao.EmUso;

        for (int i = 0; i < emUso.Count; i++) {
            CartaPorta cartaPorta = (CartaPorta)emUso[i];

            if (cartaPorta.Nome.ToLower() is not "nada") {
                emUso.RemoveAt(i);
                controle.JogadorAtual.Classe = "nada";
                mao.EmUso = emUso;
                controle.JogadorAtual.Mao = mao;
                controle.DescartarCartaPorta(cartaPorta);
                break;
            }
        }
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
