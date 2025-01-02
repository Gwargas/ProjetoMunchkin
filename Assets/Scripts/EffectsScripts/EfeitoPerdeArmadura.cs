using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeArmadura", menuName = "Scriptable Objects/EfeitoPerdeArmadura")]
public class EfeitoPerdeArmadura : Efeito
{
    public EfeitoPerdeArmadura(string titulo, int[] descricao) : base(titulo, descricao) {}

    public override void Apply(Controle controle) {
        bool removido = false;
        Hand mao = controle.JogadorAtual.Mao;

        List<Carta> carregadas = mao.Carregada;
        for (int i = 0; i < carregadas.Count; i++) {
            if (carregadas[i].GetType() == typeof(CartaEquipamento)) {
                CartaEquipamento equipamento = (CartaEquipamento) carregadas[i];
                if (equipamento.ParteCorpo == "armadura") {
                    equipamento.Efeito.Revert(controle);
                    carregadas.RemoveAt(i);
                    mao.Carregada = carregadas;
                    controle.JogadorAtual.Mao = mao;
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
                    if (equipamento.ParteCorpo == "armadura") {
                        equipamento.Efeito.Revert(controle);
                        naMao.RemoveAt(j);
                        mao.NaMao = naMao;
                        controle.JogadorAtual.Mao = mao;
                        // DEVOLVE PRO BARALHO
                        break;
                    }
                }
            }
        }
    }
    
    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
