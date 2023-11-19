using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Ray ray; // Rayon utilisé pour la détection de collision
    private RaycastHit hit; // L'objet qui a été touché par la collision
    
    [SerializeField]
    private AudioClip drinkingSound;

    [SerializeField]
    AudioClip openTabSound;

    [SerializeField]
    private StackScript stackScript; // pour référencer le script StackScript qui est attaché à l'objet Stack

    [SerializeField]
    Animator mAnimator;

    private bool canDrink = false;
    private bool canOpen = false;

    

    


    void Update()
    {
        if (stackScript.moveCan == true)
        {
            stackScript.MoveCans();
        }
        ShootRayFromScreenCenter();
    }

    public void ShootRayFromScreenCenter()
    {
        // Si je clique gauche
        if (Input.GetButtonDown("Fire1"))
        {
            if (canDrink == true && canOpen == false)
            {
                mAnimator.SetTrigger("Drinking");
                // Jouer le son de sirotage
                StartCoroutine(PlayDrinkingSound());
                canDrink = false;
            }

            if (canOpen == true && canOpen )
            {
                
                GetComponent<AudioSource>().PlayOneShot(openTabSound);
                canOpen = false;
                canDrink = true;

            }

            // Créer un rayon à partir du centre de l'écran
            Vector2 ScreenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            ray = Camera.main.ScreenPointToRay(ScreenCenterPoint);

            // Si le rayon touche un objet
            if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
            {
                
                ButtonBehaviorScript buttonScript = hit.transform.GetComponent<ButtonBehaviorScript>();
                CollectingTrayScript collectingTrayScript = hit.transform.GetComponent<CollectingTrayScript>();


                // Si l'objet touché est le bouton
                if (buttonScript != null)
                {
                    buttonScript.ButtonBehavior();
                    stackScript.moveCan = true;
                    stackScript.MoveCans();
                }

                // Si l'objet touché est le collecteur de boisson
                if (collectingTrayScript != null)
                {
                    //Faire apparaitre la canette dans la main
                    collectingTrayScript.SpawnCan();
                    canOpen = true;

                }
            }
        } 
    }

    IEnumerator PlayDrinkingSound()
    {
        yield return new WaitForSeconds(1.5f);
        GetComponent<AudioSource>().PlayOneShot(drinkingSound);
    }

}

    
  

