using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TurnSystem : MonoBehaviour

{
    public bool YourTurn;
    public int MainTurn;
    public int OppTurn;
    public TextMeshProUGUI turnText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        YourTurn = true;
        MainTurn = 1;
        OppTurn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (YourTurn == true)
        {
            turnText.text = "your turn";
        }
        else
        {
            turnText.text = "opponent turn";
        }
    }
    public void Endyourturn()
    {
        YourTurn = false;
        OppTurn += 1;
    }
    public void EndOppTurn()
    {
        YourTurn = true;
        MainTurn += 1;
    }
}
