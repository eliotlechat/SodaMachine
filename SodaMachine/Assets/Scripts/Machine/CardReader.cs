using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReader : MonoBehaviour
{
    public bool paymentCardDetected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "paymentCard")
        {
            paymentCardDetected = true;
            Machine machineScript = FindObjectOfType<Machine>();
            machineScript.hasBeenPaid = true;
        }
    }
}