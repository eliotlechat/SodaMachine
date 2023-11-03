using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    
    public AudioClip soundButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LaMethodeQuiChangeLaCouleur()
    {
        GetComponent<AudioSource>().PlayOneShot(soundButton); 
    }




}
