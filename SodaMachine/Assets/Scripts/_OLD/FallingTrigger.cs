using UnityEngine;

public class FallingTrigger : MonoBehaviour
{
    [SerializeField]
    private Machine machineScript;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        machineScript.itemsMovable = false;
    }
}