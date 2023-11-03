using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    private Ray ray;
    public RaycastHit hit;
    public canScript can;
    
    

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

            if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
            {
                Debug.Log("L'objet " + hit.transform.name + " a été touché");
                hit.transform.GetComponent<button>().LaMethodeQuiChangeLaCouleur();
                can.AddForceCan();
            }
        }
        
    }
    
}