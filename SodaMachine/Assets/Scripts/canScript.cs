using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canScript : MonoBehaviour
{
    public int valforce = 2000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddForceCan()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.right * valforce);
    }

}
