using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanScript : MonoBehaviour
{
    public AudioClip fallSound;
    
    

    private void Start()
    {
         
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "collectingTray")
        {
            ButtonBehaviorScript.isCanDropping = false;
            ButtonBehaviorScript.canBeExecuted = true;
            Debug.Log(gameObject.name + " est tomb� dans le collecteur de boisson");
            GetComponent<AudioSource>().PlayOneShot(fallSound);
            
        }
    }
    
}

