using System.Collections.Generic;
using TMPro;
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

        } else if (collision.transform.tag == "JogadorPrincipal") {
            isOverDropZone = 1;

        } else if (collision.transform.tag == "JogadorAdversario") {
            isOverDropZone = 2;

        } else if (collision.transform.tag == "AreaDelete") {
            isOverDropZone = 3;

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
            isDraggable = false;

        // se a carta estiver sobre a area do jogador, ela é equipada
        // questiona se pode equipar, equipa e tira a carta da mão caso positivo
        } else if (isOverDropZone == 1 && RemoveCartaUso()) {
            Debug.Log("Equipando");
            
        } else if (isOverDropZone == 2 && RemoveMaldicao()) {
            Debug.Log("Amaldiçoando");

        } else if (isOverDropZone == 3 && RemoveDescarte()) {
            Debug.Log("Descartando");

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
                if (naMao[i].GetType() != typeof(CartaMonstro) 
                    || controle.EstadoAtual.GetType() != typeof(EstadoPreparacao2)) {
                    return false;
                }
                
                controle.CartaJogo = naMao[i];
                controle.JogadorAtual.Mao.NaMao.RemoveAt(i);
                controle.TrocaEstado(EstadoEncrenca.CreateInstance<EstadoEncrenca>());
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

    private bool RemoveMaldicao() {
        List<Carta> naMao = controle.JogadorAtual.Mao.NaMao;
        string childNome = transform.name;

        for (int i = 0; i < naMao.Count; i++) {
            if (naMao[i].Nome.Equals(childNome)) {
                if (naMao[i].GetType() != typeof(CartaMaldição) || naMao[i].Efeito.GetType() == typeof(EfeitoAumentaMonstro)) {
                    return false;
                }

                Jogador jogadorPrincipal = controle.JogadorAtual;
                foreach (Jogador jogadorSecundario in controle.Jogadores) {
                    if (!jogadorSecundario.Nome.Equals(jogadorPrincipal.Nome)) {
                        controle.JogadorAtual = jogadorSecundario;
                        naMao[i].Efeito.Apply(controle);
                        Debug.Log($"Aplicando efeito em {controle.JogadorAtual.Nome}");
                    }
                }
                controle.JogadorAtual = jogadorPrincipal;
                controle.JogadorAtual.Mao.NaMao.RemoveAt(i);
                
                break;
            }
        }

        return true;
    }

    private bool RemoveDescarte() {
        List<Carta> naMao = controle.JogadorAtual.Mao.NaMao;
        string childNome = transform.name;
        string childDescricao = transform.Find("Descricao").GetComponent<TextMeshProUGUI>().text;

        for (int i = 0; i < naMao.Count; i++) {
            if (naMao[i].Nome.Equals(childNome) && naMao[i].Descricao.Equals(childDescricao)) {
                
                if (naMao[i].GetType() == typeof(CartaEquipamento) || naMao[i].GetType() == typeof(CartaItem)) {
                    controle.DescartarCartaTesouro(naMao[i] as CartaTesouro);

                } else {
                    controle.DescartarCartaPorta(naMao[i] as CartaPorta);
                }

                controle.JogadorAtual.Mao.NaMao.RemoveAt(i);
                break;
            }
        }

        return true;
    }
}