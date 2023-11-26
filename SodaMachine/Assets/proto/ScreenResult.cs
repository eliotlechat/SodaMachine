using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScreenResult : MonoBehaviour
{
    List<string> buttonsVal = new List<string>();
    [SerializeField]
    private TextMesh textMesh;

    public void Machin(int inputField)
    {
        buttonsVal.Add(inputField.ToString());
        if(buttonsVal.Count == 2) 
        {
            string combination = buttonsVal[0] + buttonsVal[1];
            textMesh.text = combination;
            Debug.Log("La combinaison est de " +  combination);
            buttonsVal.Clear();
        }
       
    }
}
