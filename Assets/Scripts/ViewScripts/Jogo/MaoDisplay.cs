using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class MaoDisplay : MonoBehaviour {
 
    [SerializeField] public RectTransform areaMao;
    [SerializeField] private CartaDisplay cartaDisplay;

    public void Atualiza(Controle controle) {

        Jogador jogador = controle.JogadorAtual;
        Hand jogadorMao = jogador.Mao;
        List<Carta> cartasMao = jogadorMao.NaMao;

        foreach (Carta carta in cartasMao) {
            cartaDisplay.Atualiza(carta);
        }
    }
}