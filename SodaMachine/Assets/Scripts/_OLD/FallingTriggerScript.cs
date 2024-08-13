using UnityEngine;

public class FallingTriggerScript : MonoBehaviour
{
    [SerializeField]
    private MachineScript machineScript;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        machineScript.itemsMovable = false;
    }
}