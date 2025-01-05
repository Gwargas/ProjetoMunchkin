//luiz
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour {
    private GameObject Canvas;
    private Vector3 dragScale = new Vector3(1.5f, 1.5f, 1.5f);
    private Vector3 originalScale;
    private bool isDragging = false;
    private int isOverDropZone = -1;
    private bool isDraggable = true;
    private GameObject dropZone;
    private GameObject startParent;
    private Vector2 startPosition;

    private void Start(){
        Canvas = GameObject.Find("Canvas");
        originalScale = transform.localScale;
    }

    void Update(){
        if (isDragging) {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.name == "AreaCombate") {
            isOverDropZone = 0;
            Debug.Log("Entrou na area de combate");
        } 

        else if (collision.transform.name == "JogadorImagem") {
            isOverDropZone = 1;
            Debug.Log("Vai equipar!");
        }
        else{
            isOverDropZone = -1;
        }

        dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        isOverDropZone = -1;
        dropZone = null;
    }

    public void StartDrag() {
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        isDragging = true;
        transform.localScale = dragScale;
    }

    public void EndDrag() {
        transform.localScale = originalScale;
        isDragging = false;

        // se a carta estiver sobre a area de combate, ela é jogada
        if (isOverDropZone == 0 ) {
            transform.SetParent(dropZone.transform, false);
            isDraggable = false;
            // tira a carta da mão, aplica mecanica do combate ou da encrenca

        // se a carta estiver sobre a area do jogador, ela é equipada
        } else if (isOverDropZone == 1) {
            // apagar
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
            // tira a carta da mão, equipa a carta, aplica efeito da carta
            
        } else {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }
}