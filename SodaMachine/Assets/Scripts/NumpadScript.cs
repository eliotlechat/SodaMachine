using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumpadScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] stackTab; 

    List<int>buttonsVal = new List<int>();

    [SerializeField]
    private TextMesh textMesh;

    string combinationToString;

    int combination;

    public void Combination(int inputField)
    {
        buttonsVal.Add(inputField);
        if (buttonsVal.Count == 2)
        {
            combination = buttonsVal[0]*10 + buttonsVal[1];
            combinationToString = combination.ToString();

            textMesh.text = combinationToString;
            Debug.Log("La combinaison est de " + combinationToString);
            buttonsVal.Clear();
        }

        

    }

    void ChosenStackMove()
    {
        Debug.Log("La stack " + combinationToString + "qui va se mettre en mouvement");
        GameObject chosenStack = GameObject.Find(combinationToString);
        chosenStack.GetComponent<StackScript>().MoveCans();
    }
}
