using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public AudioClip drinking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaMethodeQuiFaitRoter()
    {
        GetComponent<AudioSource>().PlayOneShot(drinking);
    }
}
