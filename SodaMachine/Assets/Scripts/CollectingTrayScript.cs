using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingTrayScript : MonoBehaviour
{
    bool isCollectible = false;

    public Material outlineMat;
    private void OnTriggerEnter(Collider other)
    {
        isCollectible = true; 
        outlineMat.SetFloat("_Scale", 1.02f);
    }

    
    private void OnApplicationQuit() // reset le outline quand je quit/
    {
        outlineMat.SetFloat("_Scale", 0f);
    }

    public void LaMethodeQuiLanceLanimation()
    {
        Debug.Log("Là il faut une anim de la boisson qui est bu");

    }


}
