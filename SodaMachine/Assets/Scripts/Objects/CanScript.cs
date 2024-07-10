using TMPro;
using UnityEngine;

public class CanScript : ItemScript
{
    [Header("Les variables de CanScript")]

    [SerializeField]
    private AudioClip openTabSound;

    [SerializeField] 
    Animator tabAnimator;
    new ParticleSystem particleSystem;


    protected override void Start() // Va écraser la méthode du parent
    {
        // Initialise le parent (l'item, donc audiosource et l'audioClip) et bease correspond au parent donc Item
        base.Start();
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    public override void Open()

    {
        if(itemIsInHand && itemIsOpened ==  false)
        {
            itemAudioSource.PlayOneShot(openTabSound);


            tabAnimator.SetTrigger("OpenTab");

            particleSystem.Play();

            itemIsOpened = true;
        }
    }


}