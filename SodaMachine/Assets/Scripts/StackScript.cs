using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackScript : MonoBehaviour
{
    [SerializeField, Tooltip("The product type that will be instantiated on the entire stack")]
    GameObject item;

    [SerializeField, Tooltip("defines the distance at which items will move")]
    float moveDistance = 0.001f;

    CollectingTrayScript collectingTrayScript;

    public bool moveCan = false;


    
    void Start()
    {   // For each child of the GameObject to which this script is attached
        foreach (Transform child in transform)
        {
            // create a new random rotation on the y axis  
            Quaternion newRotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
            // instantiate object at child's position with new rotation
            GameObject instance = Instantiate(item, child.position, newRotation);
            // the instance becomes a child of children
            instance.transform.parent = child;
        }
        // là c'est pour stocker l'objet qui contient le collectingTrayScript
        collectingTrayScript = GameObject.FindObjectOfType<CollectingTrayScript>();
        if (collectingTrayScript == null)
        {
            Debug.LogError("Aucun script CollectingTrayScript trouvé dans la scène.");
        }
    }

    

    public void MoveCans()
    {
        foreach (Transform child in transform)

           
            if (collectingTrayScript != null && !collectingTrayScript.isInCollectingTray)
            { 
                child.transform.Translate(Vector3.forward * moveDistance);
            }
            

        }

    

  
}
