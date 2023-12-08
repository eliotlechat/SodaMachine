using UnityEngine;

public abstract class ItemScript : MonoBehaviour
{
    [SerializeField]
    AudioSource itemAudioSource;

    [SerializeField]
    protected AudioClip itemFallSound;


    protected virtual void Start() // Il vaut mieux protected parce qu'il va y avoir un conflit avec l'enfant // virtual veut dire que cette méthode peut etre ovveride par un enfant
    {
        itemAudioSource = GetComponent<AudioSource>();
        if (itemAudioSource == null) itemAudioSource = gameObject.AddComponent<AudioSource>();
    }

    private void PlayFallSound()
    {
        itemAudioSource.PlayOneShot(itemFallSound);
    }

    protected abstract void Open(); //Méthode qui devra être défini pour chacun des enfants. C'est plus clair.

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CollectingTrayScript>() != null)
        {
            PlayFallSound();
        }
    }
}