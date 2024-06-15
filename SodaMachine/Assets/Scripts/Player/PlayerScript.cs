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
        GetComponent<AudioSource>().PlayOneShot(drinkingSound);
    }

    public IEnumerator PlayBurpSound()
    {

    if (!hasBurped)
        {
            hasBurped=true;
            Debug.Log("PlayBurpSound called");
            yield return new WaitForSeconds(0f);
            GetComponent<AudioSource>().PlayOneShot(burpSound);
        }
    else
        {
            Debug.Log("Burp sound has already been played");
        }
        
    }
}