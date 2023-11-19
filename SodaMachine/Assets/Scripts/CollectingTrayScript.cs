using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingTrayScript : MonoBehaviour
{
    bool isCollectible = false;
    public bool isInCollectingTray = false;
    public Material outlineMat;
    
    public FallingTriggerScript fallingTriggerScript;
    private GameObject itemFalled; // ajout d'une variable pour stocker l'objet qui est dans le collecteur

    [SerializeField]
    private GameObject hand;
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("L'objet" + collision.gameObject + "est tombé");

        itemFalled = collision.gameObject;

        isCollectible = true;
        isInCollectingTray = true;
        outlineMat.SetFloat("_Scale", 1.02f);
        fallingTriggerScript.ActiveKinematic(collision.collider);
    }


    private void OnApplicationQuit() // reset le outline quand je quit/
    {
        outlineMat.SetFloat("_Scale", 0f);
    }
    public void SpawnCan()
    {
        if(itemFalled != null)
        {
            itemFalled.transform.SetParent(hand.transform);
            itemFalled.transform.localPosition = Vector3.zero;
            itemFalled.transform.localRotation = Quaternion.identity;
            itemFalled.transform.localScale = Vector3.one;
        }
      
    }

}
