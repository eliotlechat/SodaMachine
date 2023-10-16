using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectionTray : MonoBehaviour
{
    public GameObject drinks;
    private void OnTriggerEnter(Collider drinks)
    {
        Debug.Log("La boisson est bien dans le bac de récupération");
        drinks.GetComponent<CanScript>().canMove = false;
    }




}
