using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NumpadScript : MonoBehaviour
{

    private HandScript handScript;
    public TMP_Text numpadScreen;

    int buttonVal;

    List<int> buttonsValList = new List<int>();

    private void Start()
    {
        handScript = FindObjectOfType<HandScript>();
    }

    public void ButtonValueDisplay()
    {
        GameObject buttonHit = handScript.Button;
        string buttonName = buttonHit.name.ToString();
        numpadScreen.text = buttonName;
        buttonVal = int.Parse(buttonName);
        Debug.Log("Le bouton touché est " + buttonName);
        
    }

    public void ButtonsValueCombination()
    {
        Debug.Log("Le bouton touché correspond à " + buttonVal);

        buttonsValList.Add(buttonVal);
        if (buttonsValList.Count ==2)
        {
            int combination = buttonsValList[0]*10 + buttonsValList[1];
            string combinationAsString= combination.ToString();
            numpadScreen.text = combinationAsString;
            buttonsValList.Clear();
        }
    }

}
