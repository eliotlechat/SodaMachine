using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDetectScript : MonoBehaviour
{
    
    public int inputField;

    [SerializeField]
    private TextMesh textMesh;

    [SerializeField]
    ScreenResult screenResult;

    public void OnRayCastHit()
    {        
        Debug.Log(inputField + " a �t� touch�");
        string inputFieldToString = inputField.ToString();
        textMesh.text = inputFieldToString;
        screenResult.Machin(inputField);
    }

    
}

// Je veux qu'il y ait au final 2entr�es, le premier entr�e qui fait la dixaine et l'autre l'unit�