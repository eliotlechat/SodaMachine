using TMPro;
using UnityEngine;

public class CanScript : ItemScript
{
    [Header("Les variables de CanScript")]

    [SerializeField]
    private AudioClip openTabSound;

    Animator tabAnimator;

    protected override void Start() // Va écraser la méthode du parent
    {
        // Initialise le parent (l'item, donc audiosource et l'audioClip) et bease correspond au parent donc Item
        base.Start();
    }

    public override void Open()

    {
        if(itemIsInHand && itemIsOpened ==  false)
        {
            InitializeTabAnimator();

            itemAudioSource.PlayOneShot(openTabSound);

            tabAnimator.SetTrigger("OpenTab");

            itemIsOpened = true;
        }
        
    }

    void InitializeTabAnimator()
    {
        if(tabAnimator ==  null)
        {
            tabAnimator = GetComponentInChildren<Animator>();
        }
    }
}