using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptVert : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("redSphere").GetComponent<scriptRouge>().maVariable = "Hello world";
        Debug.Log(GameObject.Find("redSphere").GetComponent<scriptRouge>().maVariable);
    }

    
    public void Destruction()
    {
        Destroy(gameObject);
    }
}
