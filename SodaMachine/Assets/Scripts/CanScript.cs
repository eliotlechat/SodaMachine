using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanScript : MonoBehaviour
{
    [SerializeField]
    AudioClip fallSound;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "collectingTray")
        {
            ButtonBehaviorScript.isCanDropping = false;
            ButtonBehaviorScript.canBeExecuted = true;
            Debug.Log(gameObject.name + " est tombé dans le collecteur de boisson");
            GetComponent<AudioSource>().PlayOneShot(fallSound);
            
        }
    }
    
}

