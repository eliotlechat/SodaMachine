using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Ray ray; // Rayon utilis� pour la d�tection de collision
    public RaycastHit hit; // L'objet qui a �t� touch� par la collision
    GameObject canAnimated;
    

    [SerializeField]
    private AudioClip drinking;

    [SerializeField]
    private StackScript stackScript;

    void Start()
    { 
         canAnimated = GameObject.Find("cocaCanAnimated");
    }


    void Update()
    {
        
        ShootRayFromScreenCenter();
    }

    public void ShootRayFromScreenCenter()
    {
        // Si je clique gauche
        if (Input.GetButtonDown("Fire1"))
        {
            // Cr�er un rayon � partir du centre de l'�cran
            Vector2 ScreenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            ray = Camera.main.ScreenPointToRay(ScreenCenterPoint);

            // Si le rayon touche un objet
            if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
            {
                
                ButtonBehaviorScript buttonScript = hit.transform.GetComponent<ButtonBehaviorScript>();
                CollectingTrayScript collectingTrayScript = hit.transform.GetComponent<CollectingTrayScript>();
                

                // Si l'objet touch� est le bouton
                if (buttonScript != null)
                {
                    buttonScript.ButtonBehavior();
                    stackScript.MoveCans();
                }

                // Si l'objet touch� est le collecteur de boisson
                if (collectingTrayScript != null)
                {
                    //Faire apparaitre la canette dans la main
                    collectingTrayScript.SpawnCan();
                    // D�marrer l'animation de la canette
                    canAnimated.GetComponent<CanAnimatedScript>().CanAnimationStart();
                    // Jouer le son de boisson
                    DrinkingPlaySound();
                }
            }
        }
    }

    public void DrinkingPlaySound()
    {
        // Jouer le son de boisson
        GetComponent<AudioSource>().PlayOneShot(drinking);
    }
}