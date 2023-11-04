using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CokesRowScripts : MonoBehaviour
{
    public int valforce = 10;
    public GameObject[] cokes;
    
    

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SelectRandomCoke()
    {
        int randomIndex = Random.Range(0, cokes.Length);
        Debug.Log("Nom de l'objet choisi : " + cokes[randomIndex].name);

        Rigidbody rb = cokes[randomIndex].GetComponent<Rigidbody>();

        if (rb != null )
        {
            rb.AddForce(transform.right * valforce);
        }
        else
        {
            Debug.Log("Aucun composant Rigidbody trouvé sur " + cokes[randomIndex].name);
        }
        
        
    }
    
   


    
}
