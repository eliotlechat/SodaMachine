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
        Debug.Log(inputField + " a été touché");
        string inputFieldToString = inputField.ToString();
        textMesh.text = inputFieldToString;
        screenResult.Machin(inputField);
    }

    
}

// Je veux qu'il y ait au final 2entrées, le premier entrée qui fait la dixaine et l'autre l'unité