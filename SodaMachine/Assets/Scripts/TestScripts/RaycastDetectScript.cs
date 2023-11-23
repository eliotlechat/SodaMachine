using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDetectScript : MonoBehaviour
{
    public void OnRayCastHit()
    {
        Debug.Log(gameObject.name + " a été touché");
    }
}
