using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoMorte", menuName = "Scriptable Objects/EfeitoMorte")]
public class EfeitoMorte : Efeito
{
    public override void Apply(Controle controle) {
        controle.JogadorAtual.Morto = true; 

        Debug.Log("Removendo cartas do Jogador");
        
        // Removendo cartas da lista EmUso
        for (int i = controle.JogadorAtual.Mao.EmUso.Count - 1; i >= 0; i--) 
        {
            Carta c = controle.JogadorAtual.Mao.EmUso[i];
            if (c.GetType() != typeof(CartaRaca) && c.GetType() != typeof(CartaClasse)) {
                controle.JogadorAtual.Mao.EmUso.RemoveAt(i);
                if (c.GetType() == typeof(CartaPorta)){
                    controle.DescartarCartaPorta(c as CartaPorta);
                }
                else if (c.GetType() == typeof(CartaTesouro)){
                    controle.DescartarCartaTesouro(c as CartaTesouro);
                }
            }
        }
        
        // Removendo cartas da lista NaMao
        for (int i = controle.JogadorAtual.Mao.NaMao.Count - 1; i >= 0; i--) {
            Carta c = controle.JogadorAtual.Mao.NaMao[i];
            controle.JogadorAtual.Mao.NaMao.RemoveAt(i);
            if (c.GetType() == typeof(CartaPorta)){
                controle.DescartarCartaPorta(c as CartaPorta);
            }
            else if (c.GetType() == typeof(CartaTesouro)){
                controle.DescartarCartaTesouro(c as CartaTesouro);
            }
        }
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
