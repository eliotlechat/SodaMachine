using UnityEngine;

public class NumpadButton : MonoBehaviour
{
    private AudioSource buttonAudioSource;

    [SerializeField]
    private AudioClip soundButton;

    private void Start()
    {
        buttonAudioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonBehavior()
    {
        buttonAudioSource.PlayOneShot(soundButton);
    }
}
