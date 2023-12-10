using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NumpadScript : MonoBehaviour
{

    private HandScript handScript;
    public TMP_Text numpadScreen;
    

    private void Start()
    {
        handScript = FindObjectOfType<HandScript>();
    }

    public void ButtonValueDisplay()
    {
        GameObject buttonHit = handScript.Button;
        numpadScreen.text = buttonHit.name;
        Debug.Log("Le bouton touché est " + buttonHit.name);
    }

    /*
    [SerializeField]
    private GameObject[] stackTab; 

    List<int>buttonsVal = new List<int>();

    [SerializeField]
    private TextMesh textMesh;

    [SerializeField]
    private GameObject stock;


    // Ca c'est la méthode qui permet de déclencher la fonction qui permet de déplacer les canettes de la stack selectionné
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

            // Ici le clavier dit à la machine que l'utilisateur a selectionné le numero XX

            // Tout ça doit plutôt être dans la machine
            Transform chosenTransform = stock.transform.Find(combinationAsString);

            if (chosenTransform != null)
            {
                GameObject chosenStack = chosenTransform.gameObject;
                Debug.Log("GameObject trouvé : " + chosenStack.name);
                chosenStack.GetComponent<StackScript>().MoveCans();
            }

            else
            {
                Debug.Log("Aucun GameObject trouvé avec le nom " + combinationAsString);
            }
        }

    }
    */

}
