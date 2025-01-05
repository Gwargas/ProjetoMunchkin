using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeItemGrande", menuName = "Scriptable Objects/EfeitoPerdeItemGrande")]
public class EfeitoPerdeItemGrande : Efeito
{

    public override void Apply(Controle controle) {
        bool removido = false;
        Hand mao = controle.JogadorAtual.Mao;

        List<Carta> emUso = mao.EmUso;
        for (int i = 0; i < emUso.Count; i++) {
            if (emUso[i].GetType() == typeof(CartaEquipamento)) {
                CartaEquipamento equipamento = (CartaEquipamento) emUso[i];
                if (equipamento.EhGrande == 1) {
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
            List<Carta> carregadas = mao.Carregada;
            for (int i = 0; i < carregadas.Count; i++) {
                if (carregadas[i].GetType() == typeof(CartaEquipamento)) {
                    CartaEquipamento equipamento = (CartaEquipamento) carregadas[i];
                    if (equipamento.EhGrande == 1) {
                        equipamento.Efeito.Revert(controle);
                        carregadas.RemoveAt(i);
                        mao.Carregada = carregadas;
                        controle.JogadorAtual.Mao = mao;
                        controle.DescartarCartaTesouro(equipamento);
                        removido = true;
                        break;
                    }
                }
            }
        }

        if (!removido) {
            List<Carta> naMao = mao.NaMao;
            for (int j = 0; j < naMao.Count; j++) {
                if (naMao[j].GetType() == typeof(CartaEquipamento)) {
                    CartaEquipamento equipamento = (CartaEquipamento) naMao[j];
                    if (equipamento.EhGrande == 1) {
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

        Debug.Log("Maldição: Perdeu um item grande :(");
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
