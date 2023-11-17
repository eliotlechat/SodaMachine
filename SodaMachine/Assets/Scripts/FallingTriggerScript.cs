using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTriggerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null )
        {
            rb.isKinematic = false;
        }
        // Il faudrait que le rb se désactive quand il touche le CollectingTrayScrupt
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
