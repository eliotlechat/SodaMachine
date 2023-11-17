using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingTrayScript : MonoBehaviour
{
    bool isCollectible = false;
    public bool isInCollectingTray = false;
    public Material outlineMat;
    GameObject boisson;
    public FallingTriggerScript fallingTriggerScript;

    private void Start()
    {
        boisson = GameObject.Find("cocaCanAnimated");

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("L'objet" + collision.gameObject + "est tombé");
      

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

        
        boisson.GetComponent<Renderer>();


        if (boisson != null)
        {
            Renderer renderer = boisson.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = true;
                

            }
            else
            {
                Debug.Log("Aucun composant Renderer trouvé sur l'objet.");
            }
        }
        else
        {
            Debug.Log("L'objet est null.");
        }
    }

    


    

  
}
