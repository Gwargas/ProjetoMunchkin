using System.Collections.Generic;
using UnityEngine;

public class CartaManager : MonoBehaviour
{
    [SerializeField] private RectTransform cartaModelo; // Prefab do GameObject "carta"
    [SerializeField] private RectTransform mao;         // Objeto pai onde as cartas serão adicionadas
    [SerializeField] private List<Carta> naMao = new List<Carta>() {
            new CartaMaldição("Carta show", "ai meu deus do ceu", null, "morto.jpg"),
            new CartaMaldição("Carta beleza", "ai meu deus do ceu", null, "morto.jpg"),
            new CartaMaldição("Carta incrivel", "ai meu deus do ceu", null, "morto.jpg"),
        };
    // public void CriarCartas(Hand maoDoJogador) {
    public void CriarCartas() {

        // Garantir que os parâmetros estejam configurados
        if (cartaModelo == null || mao == null) {
            Debug.LogError("Certifique-se de que o prefab da carta e o objeto 'hand' estão atribuídos.");
            return;
        }

        // Limpar cartas antigas
        foreach (RectTransform cartaAntiga in mao) {
            Destroy(cartaAntiga.gameObject);
        }

        // Criar as cartas
        foreach (Carta carta in naMao) {
            RectTransform novaCarta = Instantiate(cartaModelo, mao);
            novaCarta.name = carta.Nome;
            novaCarta.GetComponent<CartaExibe>().Exibe(carta.CartaPath, carta.Nome, carta.Descricao );
        }
    }
}
