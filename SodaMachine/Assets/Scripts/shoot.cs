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

        // si je clique le bouton gauche de la souris, il y a raycast au centre de l'écran. 
        if (Input.GetButtonDown("Fire1"))
        {
            Vector2 ScreenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            ray = Camera.main.ScreenPointToRay(ScreenCenterPoint);
            // Si le raycast touche un objet alors on a son nom sur la console
            if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
            {
                Debug.Log("L'objet " + hit.transform.name + " a été touché");
                // si c'est le gameObject button alors on appelle la méthode.
                hit.transform.GetComponent<CokesButton>().ButtonBehavior();



            }
        }

    }

}