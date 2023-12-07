using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleScript : ItemScript
{
    [Header("Les variables de BottleScript")]

    [SerializeField]
    GameObject openingCapBottle;

    protected override void Start() // Va �craser la m�thode du parent
    {
        // Initialise le parent (l'item, donc audiosource et l'audioClip) et bease correspond au parent donc Item
        base.Start();
    }

    protected override void Ouvrir()
    {
        Debug.Log("J'entends l'ouverture du bouchon");
        // d�clencher l'animation 
        //openingCapBottle.GetComponent<Animator>().SetTrigger("openingCapEvent");
    }

}