using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NumpadScript : MonoBehaviour
{
    [SerializeField]
    MachineScript machineScript;

    private HandScript handScript;
    public TMP_Text numpadScreen;

    public int combination;

    int buttonVal;

    List<int> buttonsValList = new List<int>();

    private void Start()
    {
        handScript = FindObjectOfType<HandScript>();
        machineScript = FindObjectOfType<MachineScript>();
    }

    public void ButtonValueDisplay()
    {
        GameObject buttonHit = handScript.Button;
        string buttonName = buttonHit.name.ToString();
        numpadScreen.text = buttonName;
        buttonVal = int.Parse(buttonName);
        Debug.Log("Le bouton touch� est " + buttonName);
        
    }

    public void ButtonsValueCombination()
    {
        Debug.Log("Le bouton touch� correspond � " + buttonVal);

        buttonsValList.Add(buttonVal);
        if (buttonsValList.Count ==2)
        {
            combination = buttonsValList[0]*10 + buttonsValList[1];
            machineScript.StackSearch();
            machineScript.itemsMovable = true;
            string combinationAsString= combination.ToString();
            numpadScreen.text = combinationAsString;
            buttonsValList.Clear();
            
        }
    }

}
