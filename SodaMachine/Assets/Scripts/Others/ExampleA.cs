using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateGameObject : MonoBehaviour
{
    public GameObject objectToInstantiate;
    public Vector3 InstantiatePosition; 

    public void InstantiateObjectAtPosition()
    {
        Instantiate(objectToInstantiate, InstantiatePosition, Quaternion.identity);
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
