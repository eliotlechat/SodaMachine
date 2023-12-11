using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private AudioSource playerAudioSource;

    [SerializeField]
    private AudioClip drinkingSound;

    private void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
        if (playerAudioSource == null) { playerAudioSource = gameObject.AddComponent<AudioSource>(); }
    }

    public IEnumerator PlayDrinkingSound()
    {
        yield return new WaitForSeconds(1.5f);
        GetComponent<AudioSource>().PlayOneShot(drinkingSound);
    }
}