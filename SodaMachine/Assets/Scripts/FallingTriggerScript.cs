using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTriggerScript : MonoBehaviour
{
    [SerializeField] 
    StackScript stackScript;


    public void OnTriggerEnter(Collider other)
    {
        //stackScript.moveCan = false;
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null )
        {
            rb.isKinematic = false;
        }     
    }

    public void ActiveKinematic(Collider other)
    {
        Rigidbody rb= other.GetComponent<Rigidbody>();
        if(rb != null )
        {
            rb.isKinematic= true;
        }
    }
}
