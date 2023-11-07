using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Ray ray;
    public RaycastHit hit;

    void Update()
    {
        ShootRayFromScreenCenter();
    }

    public void ShootRayFromScreenCenter()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            Vector2 ScreenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            ray = Camera.main.ScreenPointToRay(ScreenCenterPoint);
            
            if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane)) // si le raycast touche un objet
            {

                ButtonBehaviorScript buttonScript = hit.transform.GetComponent<ButtonBehaviorScript>();
                CollectingTrayScript collectingTrayCheck = hit.transform.GetComponent<CollectingTrayScript>();
                
                if (buttonScript != null)// Si l'objet touché est le bouton
                {
                    buttonScript.ButtonBehavior();
                }
                
                if (collectingTrayCheck != null) // Si l'object touché est le collecteur de boisson
                {
                    collectingTrayCheck.LaMethodeQuiLanceLanimation();
                }

            }

            // Si je touche l'objet collectingTray et que le CollectingTrayScript.isCollectible = true; 
            // alors je lance 
        }
    }

}