using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Linq.Expressions;
using UnityEngine.UI;
using Unity.VisualScripting;

public class InventarioDisplay : MonoBehaviour {
 
    [SerializeField] public RectTransform areaCartas;
    [SerializeField] private CartaDisplay cartaDisplay;
    [SerializeField] public GameObject menuInventario;
    private GameObject areaCombate;

    private Controle controle;
    private bool onClicked = false;

    private void Start(){
        controle = GameObject.Find("GameManager").GetComponent<GameManager>().controle;
        areaCombate = GameObject.Find("AreaCombate");

        if (menuInventario == null) {
            menuInventario = GameObject.Find("ViewManager").GetComponent<InventarioDisplay>().menuInventario;
            cartaDisplay = menuInventario.GetComponent<CartaDisplay>();
        }
        
        transform.GetComponent<Button>().onClick.RemoveAllListeners();
        transform.GetComponent<Button>().onClick.AddListener(
            () => {
                //transform.GetComponent<Button>().onClick.RemoveAllListeners();
                Debug.Log($"cliquei para abrir {transform.Find("Dono").GetComponent<TextMeshProUGUI>().text}");
                AbreInventario();
            }
        );
    }

    public void AbreInventario() {
        areaCombate.SetActive(false);
        menuInventario.SetActive(true);

        cartaDisplay = GameObject.Find("CartasEmUso").GetComponent<CartaDisplay>();
        areaCartas = cartaDisplay.areaCartas;

        string dono = transform.Find("Dono").GetComponent<TextMeshProUGUI>().text;
        Jogador jogador = controle.Jogadores.Find(j => j.Nome.Equals(dono));
        Hand jogadorMao = jogador.Mao;
        List<Carta> cartasEmUso = jogadorMao.EmUso;

        if(cartasEmUso.Count != areaCartas.childCount) {
            foreach (Carta carta in cartasEmUso) {
            cartaDisplay.Atualiza(carta);
            }   
        }
        /*
        foreach (Carta carta in cartasEmUso) {
            cartaDisplay.Atualiza(carta);
        }*/
    }

    public void FechaInventario() {
        areaCombate.SetActive(true);
        menuInventario.SetActive(false);

        foreach (Transform child in areaCartas) {
            Destroy(child.gameObject);
        }
    }
}