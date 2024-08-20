using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineStack : MonoBehaviour
{
    [SerializeField]
    GameObject stackItem;
    
    void Start()
    {
        InstantiateCansStack();
    }


    void InstantiateCansStack()
    {
        int i = 1;
        foreach (Transform child in transform)
        {

            Quaternion newRotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);

            GameObject instance = Instantiate(stackItem, child.position, newRotation);

            var parentName = transform.name;

            string newName = parentName + "_" + stackItem.name.Replace("(Clone)", "") + "_" + i;

            instance.name = newName;

            i++;

            instance.transform.parent = child;

            
        }
    }


  
}
