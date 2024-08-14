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

    public void OpeningText()
    {
        actionText.text = "Press E to open";
    }
    public void DrinkingText()
    {
        actionText.text = "Press E to drink";
    }

    public void BurpingText()
    {
        actionText.text = "Press E to burp";
    }

    public void PaymentText()
    {
        actionText.text = "Press E to pay using contactless";
    }

    public void ClearText()
    {
        actionText.text = "";
    }
}
