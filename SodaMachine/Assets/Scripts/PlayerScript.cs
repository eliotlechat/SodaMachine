using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Ray ray; // Rayon utilis� pour la d�tection de collision
    private RaycastHit hit; // L'objet qui a �t� touch� par la collision
    
    [SerializeField]
    private AudioClip drinkingSound;

    [SerializeField]
    AudioClip openTabSound;

    
    private StackScript stackScript; // pour r�f�rencer le script StackScript qui est attach� � l'objet Stack

    [SerializeField]
    private NumpadScript numpadScript;

    [SerializeField]
    Animator mAnimator;

    

    private bool canDrink = false;
    private bool canOpen = false;

    private void Start()
    {   // Pour acc�der � la m�thode MoveCans, il faut que j'acc�de au script StackScript du prefab qui sera selectionn�. 
        // Sauf que stackScript ne peut pas �tre une r�f�rence directe car il y a plusieurs possiblit�s de prefab.
        // En revanche dans le script Numpad, je connais le prefab selectionn�. 
        // Mais je ne sais pas comment y acc�der car ils y a plusieurs possiblit�s de prefab.
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

            // Cr�er un rayon � partir du centre de l'�cran
            Vector2 ScreenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            ray = Camera.main.ScreenPointToRay(ScreenCenterPoint);

            // Si le rayon touche un objet
            if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
            {
                
                ButtonScript buttonScript = hit.transform.GetComponent<ButtonScript>();
                CollectingTrayScript collectingTrayScript = hit.transform.GetComponent<CollectingTrayScript>();

                if (buttonScript != null) // si l'objet touch� est le bouton
                {
                    buttonScript.ButtonValueDisplay(); // On d�clenche le comportement du bouton et le bouton va d�clencher 
                    buttonScript.ButtonBehavior();
                    //stackScript.moveCan = true;
                    
                }

                // Si l'objet touch� est le collecteur de boisson
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

    
  

