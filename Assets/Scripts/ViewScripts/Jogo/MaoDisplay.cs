using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class MaoDisplay : MonoBehaviour {
 
    [SerializeField] public RectTransform areaMao;
    [SerializeField] private CartaDisplay cartaDisplay;
    List<Carta> cartasMao = new List<Carta>();
    private Jogador jogador =  null;

    public void Atualiza(Controle controle, JogadoresHUD jogadoresHUD) {
        bool diferente = false;
        if(jogador == null || jogador.Nome != controle.JogadorAtual.Nome) {
            diferente = true;
        }
        

        if (diferente || areaMao.childCount != cartasMao.Count) {
            jogador = controle.JogadorAtual;
            Hand jogadorMao = jogador.Mao;
            cartasMao = jogadorMao.NaMao;
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