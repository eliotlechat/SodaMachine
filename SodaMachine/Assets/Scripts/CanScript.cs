using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanScript : ItemScript
{
    [Header("Les variables de CanScript")]

    [SerializeField]
    GameObject openingTabCan;

    protected override void Start() // Va �craser la m�thode du parent
    {
        // Initialise le parent (l'item, donc audiosource et l'audioClip) et bease correspond au parent donc Item
        base.Start();
    }

    protected override void Ouvrir()
    {
        Debug.Log("J'entends le pshiit de la canette");
        // d�clencher l'animation 
        openingTabCan.GetComponent<Animator>().SetTrigger("openingTabEvent");
    }
   
}
