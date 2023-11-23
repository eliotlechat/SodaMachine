using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Raycast: MonoBehaviour
{
    private Ray ray; // Rayon utilisé pour la détection de collision
    private RaycastHit hit; // L'objet qui a été touché par la collision
    
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
                // ***** Là c'est la partie la plus cruciale qui m'intéresse le plus *******
                RaycastDetectScript raycastDetectScript = hit.transform.GetComponent<RaycastDetectScript>();
                if (raycastDetectScript != null )
                {
                    raycastDetectScript.OnRayCastHit();
                }

            }
        } 
    }

  
    
}

    
  

