using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanScript : MonoBehaviour
{
    [SerializeField]
    AudioClip fallSound;

    [SerializeField]
    GameObject openingTab;

    



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

    public void PlayOpeningTab()
    {
        Debug.Log("J'entends le pshiit de la canette");
        // d�clencher l'animation 
        openingTab.GetComponent<Animator>().SetTrigger("openingTabEvent");
    }
}

