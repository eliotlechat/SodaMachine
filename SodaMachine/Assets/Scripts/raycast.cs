using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    public void Raycast()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
        Physics.Raycast(transform.position, transform.forward, out hit, 10);
        Debug.Log("Le raycast touche l'objet");

    }
}