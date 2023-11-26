using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Raycast: MonoBehaviour
{
    private Ray ray; // Rayon utilis� pour la d�tection de collision
    private RaycastHit hit; // L'objet qui a �t� touch� par la collision
    
    void Update()
    {
        ShootRayFromScreenCenter();
    }

    public void ShootRayFromScreenCenter()
    {
        
        if (Input.GetButtonDown("Fire1")) // Si je clique gauche
        {
            
            // Cr�er un rayon � partir du centre de l'�cran
            Vector2 ScreenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            ray = Camera.main.ScreenPointToRay(ScreenCenterPoint);

            
            if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane)) // Si le rayon touche un objet
            {
                // ***** L� c'est la partie la plus cruciale qui m'int�resse le plus *******
                RaycastDetectScript raycastDetectScript = hit.transform.GetComponent<RaycastDetectScript>();
                if (raycastDetectScript != null )
                {
                    raycastDetectScript.OnRayCastHit();
                }

            }
        } 
    }

  
    
}

    
  

