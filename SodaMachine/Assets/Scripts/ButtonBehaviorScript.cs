using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviorScript : MonoBehaviour
{
    [SerializeField]
    AudioClip soundButton;
    [SerializeField]
    int valforce = 10;
    [SerializeField]
    GameObject[] row; // Tableau de la rangée de boissons
    [SerializeField]
    float waitTime = 5f; // Variable de temps d'attente avant la chute de la canette.
    [SerializeField]
    //float delayTime = 10f;
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
            



        }
    }

    

   

}
