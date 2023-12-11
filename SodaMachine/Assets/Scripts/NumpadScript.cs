using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumpadScript : MonoBehaviour
{
    [SerializeField]
    private MachineScript machineScript;

    private HandScript handScript;
    public TMP_Text numpadScreen;

    public int combination;

    private int buttonVal;

    private List<int> buttonsValList = new List<int>();

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
        }
    }
}