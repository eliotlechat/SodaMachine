using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemScript : MonoBehaviour
{
    
    [SerializeField]
    protected AudioClip itemFallSound;

    AudioSource itemAudioSource;

    protected virtual void Start()
    {
        itemAudioSource = GetComponent<AudioSource>();
        if(itemAudioSource == null) itemAudioSource = gameObject.AddComponent<AudioSource>();
    }

    void PlayFallSound()
    {
        itemAudioSource.PlayOneShot(itemFallSound);
    }

    protected abstract void Ouvrir();


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CollectingTrayScript>()!=null)
        {
            PlayFallSound();
            
            
        }
            
        
        
    }
}
