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

    int combination;

    public void Combination(int inputField)
    {
        buttonsVal.Add(inputField);
        if (buttonsVal.Count == 2)
        {
            combination = buttonsVal[0]*10 + buttonsVal[1];
            string combinationToString = combination.ToString();

            textMesh.text = combinationToString;
            Debug.Log("La combinaison est de " + combinationToString);
            buttonsVal.Clear();
        }

        // en gros là je devrais faire quelque chose comme si la combination est : 11 alors je mets la stack 11

    }

    void Machin()
    {
        if (combination == 11)
        {
            // choisir la stack stackTab[0]
        }
    }
}
