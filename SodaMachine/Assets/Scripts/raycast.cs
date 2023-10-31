using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    public void Raycast()
    {
        
   
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
        RaycastHit hit; 
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
            Debug.Log("un objet traverse le rayon");
        }

    }
}