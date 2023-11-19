using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviorScript : MonoBehaviour
{
    [SerializeField]
    AudioClip soundButton;

    [SerializeField]
    GameObject[] row; // Tableau de la rang�e de boissons


    public static bool canBeExecuted = true;
    /// private Renderer rend;
    public static bool isCanDropping = false;


    void Start()
    {
        // au start je recup�re le composant renderer pour pouvoir utiliser l'emission
        /// rend = GetComponent<Renderer>(); 

    }


    public void ButtonBehavior()
    {
        
        if (canBeExecuted == true && isCanDropping == false) 
        {
            canBeExecuted = false;
            isCanDropping = true;
            GetComponent<AudioSource>().PlayOneShot(soundButton);

        }
    }

    

   

}
