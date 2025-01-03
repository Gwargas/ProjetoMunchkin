using System.Collections.Generic;
using UnityEngine;

public class CartaManager : MonoBehaviour
{
    [SerializeField] private RectTransform cartaModelo; // Prefab do GameObject "carta"
    [SerializeField] private RectTransform mao;         // Objeto pai onde as cartas serão adicionadas
    [SerializeField] private List<Carta> naMao = new List<Carta>() {};
    // public void CriarCartas(Hand maoDoJogador) {
    public void CriarCartas() {

        for (int i = 0; i < 5; i++) {
            CartaMaldição cartaPorta = CartaMaldição.CreateInstance<CartaMaldição>();
            cartaPorta.Inicializa($"Carta {i+1}", $"Show de bola {i+5}", null, "morto.png");
            naMao.Add(cartaPorta);
        }

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
            
            //novaCarta.GetComponent<CartaExibe>().Exibe(carta.CartaPath, carta.Nome, carta.Descricao );
        }
    }
}
