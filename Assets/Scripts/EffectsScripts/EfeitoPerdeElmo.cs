using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeElmo", menuName = "Scriptable Objects/EfeitoPerdeElmo")]
public class EfeitoPerdeElmo : Efeito
{
    public EfeitoPerdeElmo(string titulo, int[] descricao) : base(titulo, descricao)
    {
    }
    public override void Apply(Controle controle) {
        bool removido = false;
        Hand mao = controle.JogadorAtual.Mao;

        List<Carta> carregadas = mao.Carregada;
        for (int i = 0; i < carregadas.Count; i++) {
            if (carregadas[i].GetType() == typeof(CartaEquipamento)) {
                CartaEquipamento equipamento = (CartaEquipamento) carregadas[i];
                if (equipamento.ParteCorpo == "elmo") {
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
                    if (equipamento.ParteCorpo == "elmo") {
                        equipamento.Efeito.Revert(controle);
                        naMao.RemoveAt(j);
                        // DEVOLVE PRO BARALHO
                        break;
                    }
                }
            }
        }
    }

    public override CartaMonstro Apply(CartaMonstro carta)
    {
        throw new System.NotImplementedException();
    }

    public override CartaMonstro Revert(CartaMonstro carta)
    {
        throw new System.NotImplementedException();
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
