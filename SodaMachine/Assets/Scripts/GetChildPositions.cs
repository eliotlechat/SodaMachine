using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetChildPositions2 : MonoBehaviour
{
    private Vector3[] childPosition; 

    // Start is called before the first frame update
    void Start()
    {
        // la taille du tableau correspond aux nombres d'enfants.
        childPosition = new Vector3[transform.childCount];
        
        // parcourir tous les enfants 
        for (int i = 0; i < transform.childCount; i++)
        {
            // ajouter la position de l'enfant aau tableau
            childPosition[i] = transform.GetChild(i).position;
        }
        foreach(Vector3 position in childPosition)
        {
            Debug.Log(position);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // obtenir les positions dans la console
}
