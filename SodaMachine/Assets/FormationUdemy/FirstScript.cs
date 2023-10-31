using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{
    string[] tableau = new string[4];
    
    void Start()
    {
        tableau[0]= "ligne 1";
        tableau[1] = "ligne 2";
        tableau[2] = "ligne 3";
        tableau[3] = "ligne 4";

        foreach (string temp in tableau)
        {
            Debug.Log(temp);        }
    }
    void Update()
    {
        
    }
}
