using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviorScript : MonoBehaviour
{
    
    public AudioClip soundButton;
    public int valforce = 10;
    public GameObject[] row; // Tableau de la rangée de boissons
    public float waitTime = 5f; // Variable de temps d'attente avant la chute de la canette.
    public float delayTime = 10f;
    public bool canBeExecuted = true;
    private Renderer rend;
    public static bool isCanDropping = false;


    void Start()
    {
        // au start je recupère le composant renderer pour pouvoir utiliser l'emission
        rend = GetComponent<Renderer>(); 
    }


    public void ButtonBehavior()
    {
        if (canBeExecuted == true && isCanDropping == false) 
        {
            canBeExecuted = false;
            isCanDropping=true;
            GetComponent<AudioSource>().PlayOneShot(soundButton);
            StartCoroutine(SelectRandomCan());
            rend.material.EnableKeyword("_EMISSION");
        }
    }

    public void DisableEmission() 
    {
        rend.material.DisableKeyword("_EMISSION");
    }

    IEnumerator SelectRandomCan()
    {
        yield return new WaitForSeconds(waitTime); // Attendre pendant 'waitTime' secondes
       
        int randomIndex = Random.Range(0, row.Length);
        Debug.Log("Nom de l'objet choisi : " + row[randomIndex].name);

        Rigidbody rb = row[randomIndex].GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(transform.forward * valforce);
        }
        else
        {
            Debug.Log("Aucun composant Rigidbody trouvé sur " + row[randomIndex].name);
        }

        
    }

}
