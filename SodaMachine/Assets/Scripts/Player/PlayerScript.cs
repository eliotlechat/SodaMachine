using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private AudioSource playerAudioSource;

    [SerializeField]
    private AudioClip drinkingSound;

    [SerializeField]
    private AudioClip burpSound;

    private bool hasBurped = false;

    private void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
        if (playerAudioSource == null) { playerAudioSource = gameObject.AddComponent<AudioSource>(); }
    }

    public IEnumerator PlayDrinkingSound()
    {
        Debug.Log("PlayDrinkingSound called");
        yield return new WaitForSeconds(1.5f);
        playerAudioSource.PlayOneShot(drinkingSound);

        yield return new WaitWhile(()=>playerAudioSource.isPlaying);
        Debug.Log("Drinking sound finished");

    }

    public void PlayBurpSound()
    {

    if (!hasBurped)
        {
            hasBurped=true;
            Debug.Log("PlayBurpSound called");
            
            GetComponent<AudioSource>().PlayOneShot(burpSound);
        }
    else
        {
            Debug.Log("Burp sound has already been played");
        }
        
    }
}