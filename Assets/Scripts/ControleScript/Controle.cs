using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Controle", menuName = "Scriptable Objects/Controle")]
public class Controle : ScriptableObject
{
    List<Jogador> jogadores = new List<Jogador>();
    BaralhoPorta baralho_porta = new BaralhoPorta();
    BaralhoTesouro baralho_tesouro = new BaralhoTesouro();
    DescartePorta descarte_porta = new DescartePorta();
    DescarteTesouro descarte_tesouro = new DescarteTesouro();
    List<Deck> decks = new List<Deck>() {};//era para ter cada um(bp,bt,dp,dt) aqui;

    public void turno() {}
}
