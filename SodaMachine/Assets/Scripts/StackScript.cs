using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackScript : MonoBehaviour
{
    [SerializeField]
    GameObject stackItem;
    
    void Start()
    {
        InstantiateCansStack();
    }


    void InstantiateCansStack()
    {
        int i = 0;
        foreach (Transform child in transform)
        {

            Quaternion newRotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);

            GameObject instance = Instantiate(stackItem, child.position, newRotation);

            instance.name += "_" + i;

            i++;

            instance.transform.parent = child;
        }
    }


  
}
