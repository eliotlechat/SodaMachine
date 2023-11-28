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

    [SerializeField]
    private GameObject stock;


    // Ca c'est la m�thode qui permet de d�clencher la fonction qui permet de d�placer les canettes de la stack selectionn�
    public void CombinationForMovingCans(int inputField)
    {
        buttonsVal.Add(inputField);
        if (buttonsVal.Count == 2)
        {
            int combination = buttonsVal[0]*10 + buttonsVal[1];
            string combinationAsString = combination.ToString();

            textMesh.text = combinationAsString;
            Debug.Log("La combinaison est de " + combinationAsString);
            buttonsVal.Clear();

            Transform chosenTransform = stock.transform.Find(combinationAsString);

            if (chosenTransform != null)
            {
                GameObject chosenStack = chosenTransform.gameObject;
                Debug.Log("GameObject trouv� : " + chosenStack.name);
                chosenStack.GetComponent<StackScript>().MoveCans();
            }
            else
            {
                Debug.Log("Aucun GameObject trouv� avec le nom " + combinationAsString);
            }
        }

    }

    
}
