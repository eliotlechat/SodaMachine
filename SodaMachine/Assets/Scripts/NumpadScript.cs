using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Collections;

public class NumpadScript : MonoBehaviour
{
    MachineScript machineScript;

    private HandScript handScript;
    public TMP_Text numpadScreen;

    [HideInInspector]
    public int combination;

    public bool isPriceDisplayed = false;

    const float itemPrice = 2.30f;

    private int buttonVal;

    private List<int> buttonsValList = new List<int>();

    public bool isCombinationFormed = false;




    private void Start()
    {
        handScript = FindObjectOfType<HandScript>();
        machineScript = FindObjectOfType<MachineScript>();
    }

    public void DisplayButtonValue()
    {
        GameObject buttonHit = handScript.Button;
        string buttonName = buttonHit.name.ToString();
        numpadScreen.text = buttonName;
        buttonVal = int.Parse(buttonName);
    }

    public void ButtonsValueCombination()
    {
        Debug.Log("Le bouton touché correspond à " + buttonVal);

        buttonsValList.Add(buttonVal);
        if (buttonsValList.Count == 2)
        {
            combination = buttonsValList[0] * 10 + buttonsValList[1];
            string combinationAsString = combination.ToString();
            machineScript.StackSearch();
            machineScript.itemsMovable = true;
            numpadScreen.text = combinationAsString;
            buttonsValList.Clear();

            Debug.Log("The object has been selected");
            StartCoroutine(DisplayItemPriceWithDelay());

        }
    }

    private IEnumerator DisplayItemPriceWithDelay()
    {

        yield return new WaitForSeconds(0.5f);
        numpadScreen.text = itemPrice.ToString();
        isPriceDisplayed = true;

    }

    public void ResetScreen()
    {
        numpadScreen.text = "";
        isPriceDisplayed= false;
        buttonsValList.Clear();
        combination = 0;
        isCombinationFormed = false;
    }

    
}