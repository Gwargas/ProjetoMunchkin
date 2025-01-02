using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeItemPequeno", menuName = "Scriptable Objects/EfeitoPerdeItemPequeno")]
public class EfeitoPerdeItemPequeno : Efeito
{
    public EfeitoPerdeItemPequeno(string titulo, int[] valores) : base(titulo, valores)
    {
    }

    public override void Apply(Controle controle) {
        bool removido = false;
        Hand mao = controle.JogadorAtual.Mao;

        List<Carta> carregadas = mao.Carregada;
        for (int i = 0; i < carregadas.Count; i++) {
            if (carregadas[i].GetType() == typeof(CartaEquipamento)) {
                CartaEquipamento equipamento = (CartaEquipamento) carregadas[i];
                if (equipamento.EhGrande == 0) {
                    equipamento.Efeito.Revert(controle);
                    carregadas.RemoveAt(i);
                    // DEVOLVE PRO BARALHO
                    removido = true;
                    break;
                }
            }
        }

        if (!removido) {
            List<Carta> naMao = mao.NaMao;
            for (int j = 0; j < naMao.Count; j++) {
                if (naMao[j].GetType() == typeof(CartaEquipamento)) {
                    CartaEquipamento equipamento = (CartaEquipamento) naMao[j];
                    if (equipamento.EhGrande == 0) {
                        equipamento.Efeito.Revert(controle);
                        naMao.RemoveAt(j);
                        // DEVOLVE PRO BARALHO
                        break;
                    }
                }
            }
        }
    }
}
