using UnityEngine;

public class CanScript : ItemScript
{
    [Header("Les variables de CanScript")]
    [SerializeField]
    private GameObject openingTabCan;

    [SerializeField]
    private AudioClip openTabSound;

    protected override void Start() // Va écraser la méthode du parent
    {
        // Initialise le parent (l'item, donc audiosource et l'audioClip) et bease correspond au parent donc Item
        base.Start();
    }

    protected override void Open()

    {
        Debug.Log("J'entends le pshiit de la canette");
        // déclencher l'animation
        openingTabCan.GetComponent<Animator>().SetTrigger("openingTabEvent");
    }
}