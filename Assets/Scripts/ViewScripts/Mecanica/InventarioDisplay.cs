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
    //private bool onClicked = false;

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

        if(jogador.Mao.EmUso.Count != areaCartas.childCount) {
            foreach (Carta carta in jogador.Mao.EmUso) {
                cartaDisplay.Atualiza(carta);
            }   
        }
    }

    public void FechaInventario() {
        areaCombate.SetActive(true);
        menuInventario.SetActive(false);

        foreach (Transform child in areaCartas) {
            Destroy(child.gameObject);
        }
    }
}