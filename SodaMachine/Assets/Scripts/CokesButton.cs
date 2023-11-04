using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CokesButton : MonoBehaviour
{
    
    public AudioClip soundButton;
    public CokesRowScripts cokesRowScripts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ButtonBehavior()
    {
        GetComponent<AudioSource>().PlayOneShot(soundButton);
        cokesRowScripts.SelectRandomCoke();
    }




}
