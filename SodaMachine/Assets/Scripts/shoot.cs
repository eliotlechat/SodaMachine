using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Ray ray;
    public RaycastHit hit;
    GameObject canAnimated;
    GameObject player;

    private void Start()
    {
        canAnimated = GameObject.Find("cocaCanAnimated");
        player = GameObject.Find("Player");
    }

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
                CollectingTrayScript collectingTrayScript = hit.transform.GetComponent<CollectingTrayScript>();
                CanAnimatedScript canAnimatedScript = canAnimated.GetComponent<CanAnimatedScript>();
                PlayerScript playerScript = player.GetComponent<PlayerScript>();


                if (buttonScript != null)// Si l'objet touché est le bouton
                {
                    buttonScript.ButtonBehavior();
                }
                
                if (collectingTrayScript != null) // Si l'object touché est le collecteur de boisson
                {
                    collectingTrayScript.LaMethodeQuiFaitApparaitreLaBoisson();
                    canAnimatedScript.LaMethodeQuiLancelAnimation();
                    playerScript.LaMethodeQuiFaitRoter();


                }
            }      
        }
    }
}