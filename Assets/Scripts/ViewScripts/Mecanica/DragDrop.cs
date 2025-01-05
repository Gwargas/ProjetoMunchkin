//luiz
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DragDrop : MonoBehaviour {
    private bool isDragging = false;
    private int isOverDropZone = -1;
    private bool isDraggable = true;
    private GameObject dropZone;
    private GameObject startParent;
    private Vector2 startPosition;

    private Controle controle;

    private void Start(){
        controle = GameObject.Find("GameManager").GetComponent<GameManager>().controle;
    }

    void Update(){
        if (isDraggable && isDragging) {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.transform.name == "AreaCombate") {
            isOverDropZone = 0;

        } else if (collision.transform.name == "JogadorImagem") {
            isOverDropZone = 1;

        } else{
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
    }

    public void EndDrag() {
        isDragging = false;

        // se a carta estiver sobre a area de combate, ela é jogada
        // questiona se pode usar na área de combate, tira a carta da mão caso positivo
        if (isOverDropZone == 0 && RemoveCartaCombate()) {
            Debug.Log("Entrou na area de combate");
            
            transform.SetParent(dropZone.transform, false);
            isDraggable = false;

        // se a carta estiver sobre a area do jogador, ela é equipada
        // questiona se pode equipar, equipa e tira a carta da mão caso positivo
        } else if (isOverDropZone == 1 && RemoveCartaUso()) {
            Debug.Log("Vai equipar!");
            
        } else {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }

    private bool RemoveCartaCombate() {
        List<Carta> naMao = controle.JogadorAtual.Mao.NaMao;
        string childNome = transform.name;
        string childDescricao = transform.Find("Descricao").GetComponent<TextMeshProUGUI>().text;

        for (int i = 0; i < naMao.Count; i++) {
            if (naMao[i].Nome.Equals(childNome) && naMao[i].Descricao.Equals(childDescricao)) {
                if (naMao[i].GetType() != typeof(CartaMaldição) && naMao[i].GetType() != typeof(CartaMonstro)) {
                    return false;
                }

                controle.DescartarCartaPorta((CartaPorta)naMao[i]);
                controle.JogadorAtual.Mao.NaMao.RemoveAt(i);
                break;
            }
        }

        return true;
    }

    private bool RemoveCartaUso() {
        List<Carta> naMao = controle.JogadorAtual.Mao.NaMao;
        string childNome = transform.name;

        for (int i = 0; i < naMao.Count; i++) {
            if (naMao[i].Nome.Equals(childNome)) {
                if (naMao[i].GetType() == typeof(CartaMaldição) || naMao[i].GetType() == typeof(CartaMonstro)) {
                    return false;
                }

                controle.JogadorAtual.Mao.equiparItem(naMao[i]);
                naMao[i].Efeito.Apply(controle);
                controle.JogadorAtual.Mao.NaMao.RemoveAt(i);
                break;
            }
        }

        return true;
    }
}