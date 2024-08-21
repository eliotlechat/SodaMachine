using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReader : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "paymentCard")
        {
            Machine machineScript = FindObjectOfType<Machine>();
            machineScript.hasBeenPaid = true;
        }
    }
}