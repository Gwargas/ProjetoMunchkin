//luiz

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragDrop : MonoBehaviour
{
    public GameObject Canvas;
    private Vector3 dragScale = new Vector3(1.5f, 1.5f, 1.5f);
    private Vector3 originalScale;
    private bool isDragging = false;
    private bool isOverDropZone = false;
    private bool isDraggable = true;
    private GameObject dropZone;
    private GameObject startParent;
    private Vector2 startPosition;

    private void Start()
    {

        Canvas = GameObject.Find("Canvas1");
        originalScale = transform.localScale;
    }
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        isOverDropZone = true;
        dropZone = collision.gameObject;

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag()
    {

        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        isDragging = true;
        transform.localScale = dragScale;
    }

    public void EndDrag()
    {
        transform.localScale = originalScale;
        isDragging = false;

        if (isOverDropZone)
        {
            transform.SetParent(dropZone.transform, false);
            isDraggable = false;

        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }
}