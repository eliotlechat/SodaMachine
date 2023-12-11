using UnityEngine;

public class CanScript : ItemScript
{
    [Header("Les variables de CanScript")]
    [SerializeField]
    private GameObject openingTabCan;

    

    [SerializeField]
    private AudioClip openTabSound;

    protected override void Start() // Va �craser la m�thode du parent
    {
        // Initialise le parent (l'item, donc audiosource et l'audioClip) et bease correspond au parent donc Item
        base.Start();
    }

    public override void Open()

    {
        if(itemIsInHand && itemIsOpened ==  false)
        {
            itemAudioSource.PlayOneShot(openTabSound);

            // d�clencher l'animation
            openingTabCan.GetComponent<Animator>().SetTrigger("openingTabEvent");
        }
        
    }
}