using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Numpad : MonoBehaviour
{
    private Machine machineScript;

    private Raycast raycastScript;
    public TMP_Text numpadScreen;

    [HideInInspector]
    public int combination;

    public bool isPriceDisplayed = false;

    private const float itemPrice = 2.30f;

    private int buttonVal;

    private List<int> buttonsValList = new List<int>();

    public bool isCombinationFormed = false;

    private Interface interfaceScript;

    private void Start()
    {
        raycastScript = FindObjectOfType<Raycast>();
        machineScript = FindObjectOfType<Machine>();
        interfaceScript = FindObjectOfType<Interface>();
    }

    public void DisplayButtonValue()
    {
        GameObject buttonHit = raycastScript.Numpadbutton;
        string buttonName = buttonHit.name.ToString();
        numpadScreen.text = buttonName;
        buttonVal = int.Parse(buttonName);
    }

    public void ButtonsValueCombination()
    {
        buttonsValList.Add(buttonVal);
        if (buttonsValList.Count == 2)
        {
            combination = buttonsValList[0] * 10 + buttonsValList[1];
            string combinationAsString = combination.ToString();
            machineScript.StackSearch();
            machineScript.itemsMovable = true;
            numpadScreen.text = combinationAsString;
            buttonsValList.Clear();

            StartCoroutine(DisplayItemPriceWithDelay());
        }
    }

    private IEnumerator DisplayItemPriceWithDelay()
    {
        yield return new WaitForSeconds(0.5f);
        numpadScreen.text = itemPrice.ToString();
        isPriceDisplayed = true;
        interfaceScript.PaymentText();
    }

    public void ResetScreen()
    {
        numpadScreen.text = "";
        isPriceDisplayed = false;
        buttonsValList.Clear();
        combination = 0;
        isCombinationFormed = false;
    }

    public void SetButtonsInteractable(bool interactable)
    {
        NumpadButton[] allButtons = FindObjectsOfType<NumpadButton>();
        foreach (var button in allButtons)
        {
            Collider buttonCollider = button.GetComponent<Collider>();
            if (buttonCollider != null)
            {
                buttonCollider.enabled = interactable;
            }
        }
    }
}