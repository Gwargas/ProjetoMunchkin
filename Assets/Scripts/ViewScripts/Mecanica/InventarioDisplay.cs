using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Linq.Expressions;
using UnityEngine.UI;
using Unity.VisualScripting;

public class InventarioDisplay : MonoBehaviour {
 
    [SerializeField] public GameObject menuInventario;
    [SerializeField] public RectTransform areaCartas;
    [SerializeField] private CartaDisplay cartaDisplay;

    private Controle controle;

    private void Start(){
        controle = GameObject.Find("GameManager").GetComponent<GameManager>().controle;
        //cartaDisplay = menuInventario.GetComponent<CartaDisplay>();
        //areaCartas = cartaDisplay.areaCartas;

        transform.GetComponent<Button>().onClick.RemoveAllListeners();
        transform.GetComponent<Button>().onClick.AddListener(
            () => {
                Debug.Log($"cliquei para abrir {transform.Find("Dono").GetComponent<TextMeshProUGUI>().text}");
            }
        );
    }

    public void AbreInventario() {
        GameObject.Find("AreaCombate").SetActive(false);
        menuInventario.SetActive(true);

        string dono = transform.Find("Dono").GetComponent<TextMeshProUGUI>().text;
        Jogador jogador = controle.Jogadores.Find(j => j.Nome.Equals(dono));
        Hand jogadorMao = jogador.Mao;
        List<Carta> cartasEmUso = jogadorMao.EmUso;

        foreach (Carta carta in cartasEmUso) {
            cartaDisplay.Atualiza(carta);
        }
    }

    public void FechaInventario() {

        GameObject.Find("AreaCombate").SetActive(true);
        menuInventario.SetActive(false);

        foreach (Transform child in areaCartas) {
            Destroy(child.gameObject);
        }
    }
}