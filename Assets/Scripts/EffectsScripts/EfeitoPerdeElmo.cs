using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeElmo", menuName = "Scriptable Objects/EfeitoPerdeElmo")]
public class EfeitoPerdeElmo : Efeito
{

    public override void Apply(Controle controle) {
        bool removido = false;
        Hand mao = controle.JogadorAtual.Mao;

        List<Carta> emUso = mao.EmUso;
        for (int i = 0; i < emUso.Count; i++) {
            if (emUso[i].GetType() == typeof(CartaEquipamento)) {
                CartaEquipamento equipamento = emUso[i] as CartaEquipamento;
                if (equipamento.ParteCorpo == "elmo") {
                    equipamento.Efeito.Revert(controle);
                    emUso.RemoveAt(i);
                    mao.EmUso = emUso;
                    controle.JogadorAtual.Mao = mao;
                    controle.DescartarCartaTesouro(equipamento);
                    removido = true;
                    break;
                }
            }
        }

        if (!removido) {
            List<Carta> naMao = mao.NaMao;
            for (int j = 0; j < naMao.Count; j++) {
                if (naMao[j].GetType() == typeof(CartaEquipamento)) {
                    CartaEquipamento equipamento = naMao[j] as CartaEquipamento;
                    if (equipamento.ParteCorpo.Equals("elmo")) {
                        equipamento.Efeito.Revert(controle);
                        naMao.RemoveAt(j);
                        mao.NaMao = naMao;
                        controle.JogadorAtual.Mao = mao;
                        controle.DescartarCartaTesouro(equipamento);
                        break;
                    }
                }
            }
        }
        Debug.Log("Maldição: Perdeu um elmo :(");
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
