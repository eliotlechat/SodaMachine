using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingTrayScript : MonoBehaviour
{
    bool isCollectible = false;
    public Material outlineMat;
    GameObject boisson;


    private void Start()
    {
        boisson = GameObject.Find("cocaCanAnimated");

    }
    
    private void OnTriggerEnter(Collider other)
    {
        isCollectible = true; 
        outlineMat.SetFloat("_Scale", 1.02f);
    }

    
    private void OnApplicationQuit() // reset le outline quand je quit/
    {
        outlineMat.SetFloat("_Scale", 0f);
    }
    public void SpawnCan()
    {

        Debug.Log("blabla");
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
