using UnityEngine;

public class CartaDestaca : MonoBehaviour {
    [SerializeField] public RectTransform carta;
    private int indiceInicial;

    public void MouseEntra() {
        indiceInicial = carta.GetSiblingIndex();
        carta.SetAsLastSibling();
    }

    public void MouseSai() {
        carta.SetSiblingIndex(indiceInicial);
    }
}
