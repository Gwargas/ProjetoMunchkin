using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class MaoDisplay : MonoBehaviour {
 
    [SerializeField] public RectTransform areaMao;
    [SerializeField] private CartaDisplay cartaDisplay;

    public void Atualiza(Controle controle, JogadoresHUD jogadoresHUD) {

        Jogador jogador = controle.JogadorAtual;
        Hand jogadorMao = jogador.Mao;
        List<Carta> cartasMao = jogadorMao.NaMao;

        if (areaMao.childCount != cartasMao.Count) {
            jogadoresHUD.Atualiza(controle);
            foreach(Transform child in areaMao) {
                Destroy(child.gameObject);
            }

            foreach (Carta carta in cartasMao) {
                cartaDisplay.Atualiza(carta);
            }
        }
    }
}