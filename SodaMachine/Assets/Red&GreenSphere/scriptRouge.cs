using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptRouge : MonoBehaviour
{
	public string maVariable="Je suis la sphére rouge";
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("greenSphere").GetComponent<ScriptVert>().Destruction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
