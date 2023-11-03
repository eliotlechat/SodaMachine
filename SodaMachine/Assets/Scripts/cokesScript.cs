using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cokesScripts : MonoBehaviour
{
    public int valforce = 10;
    public void SelectCokesCan()
    {

        GetComponent<Rigidbody>().AddForce(Vector3.right * valforce);
    }
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
