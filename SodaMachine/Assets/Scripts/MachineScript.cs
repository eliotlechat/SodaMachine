using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineScript : MonoBehaviour
{
    [SerializeField]
    GameObject stackReference; // Dans cette classe, il y aura les references des étagères. ou Stack

    float canMovementDistance = 0.001f;

    

    public bool itemsMovable = false;


  
    private void Update()
    {
        MoveItems();
            
    }

    public void MoveItems()
    {
        if (itemsMovable)
        {
            foreach (Transform child in stackReference.transform)

            {
                child.transform.Translate(Vector3.forward * canMovementDistance);

            }
        }
        
    }
}
