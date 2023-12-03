using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTriggerScript : MonoBehaviour
{
    [SerializeField]
    MachineScript machineScript;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        machineScript.itemsMovable = false;
    }


}
