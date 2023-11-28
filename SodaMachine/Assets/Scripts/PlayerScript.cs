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

    
    private StackScript stackScript; // pour référencer le script StackScript qui est attaché à l'objet Stack

    [SerializeField]
    private NumpadScript numpadScript;

    [SerializeField]
    Animator mAnimator;

    

    private bool canDrink = false;
    private bool canOpen = false;

    private void Start()
    {   // Pour accéder à la méthode MoveCans, il faut que j'accède au script StackScript du prefab qui sera selectionné. 
        // Sauf que stackScript ne peut pas être une référence directe car il y a plusieurs possiblités de prefab.
        // En revanche dans le script Numpad, je connais le prefab selectionné. 
        // Mais je ne sais pas comment y accéder car ils y a plusieurs possiblités de prefab.
        //stackScript = 
    }


    void Update()
    {
        //if (stackScript.moveCan == true)
        //{
        //    stackScript.MoveCans();
        //}
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
                
                ButtonScript buttonScript = hit.transform.GetComponent<ButtonScript>();
                CollectingTrayScript collectingTrayScript = hit.transform.GetComponent<CollectingTrayScript>();

                if (buttonScript != null) // si l'objet touché est le bouton
                {
                    buttonScript.ButtonValueDisplay(); // On déclenche le comportement du bouton et le bouton va déclencher 
                    buttonScript.ButtonBehavior();
                    //stackScript.moveCan = true;
                    
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

    
  

