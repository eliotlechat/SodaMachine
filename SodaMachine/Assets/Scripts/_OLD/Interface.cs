using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Interface : MonoBehaviour
{

    
    public TMP_Text actionText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayOpenItemText()
    {
        actionText.text = "Press E to open";
    }
    public void DisplayDrinkText()
    {
        actionText.text = "Press E to drink";
    }

    public void DisplayBurpText()
    {
        actionText.text = "Press E to burp";
    }

    public void DisplayPaymentText()
    {
        actionText.text = "Press E to pay using contactless";
    }

    public void ClearText()
    {
        actionText.text = "";
    }
}
