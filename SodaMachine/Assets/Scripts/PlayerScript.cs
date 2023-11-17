using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Ray ray; // Rayon utilisé pour la détection de collision
    public RaycastHit hit; // L'objet qui a été touché par la collision
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
                    stackScript.MoveCans();
                }

                // Si l'objet touché est le collecteur de boisson
                if (collectingTrayScript != null)
                {
                    //Faire apparaitre la canette dans la main
                    collectingTrayScript.SpawnCan();
                    // Démarrer l'animation de la canette
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