using UnityEngine;

public class CardHighlight : MonoBehaviour {
    [SerializeField] private RectTransform _card;
    private int originalIdx;
    private Vector3 originalPos;
    private float offset = 0.0f;

    public void MouseEnter() {
        originalIdx = _card.GetSiblingIndex();
        originalPos = _card.localPosition;

        _card.SetAsLastSibling();
        _card.localPosition = originalPos + Vector3.up * offset;
    }

    public void MouseExit() {
        _card.SetSiblingIndex(originalIdx);
        _card.localPosition = originalPos;
    }
}
