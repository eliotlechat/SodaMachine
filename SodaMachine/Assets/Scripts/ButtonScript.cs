using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    int inputField;

    public void OnRaycastHit()
    {
        Debug.Log(inputField + " a été touché");
    }
}
