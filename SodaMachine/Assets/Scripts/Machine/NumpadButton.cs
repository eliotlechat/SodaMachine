using UnityEngine;

public class NumpadButton : MonoBehaviour
{
    private AudioSource buttonAudioSource;

    [SerializeField]
    private AudioClip soundButton;

    private Numpad numpadScript; 

    private void Start()
    {
        buttonAudioSource = GetComponent<AudioSource>();
        numpadScript = FindObjectOfType<Numpad>();
    }

    public void HitNumpadButtonBehavior()
    {
        buttonAudioSource.PlayOneShot(soundButton);
        numpadScript.DisplayButtonValue();
        numpadScript.ButtonsValueCombination();
    }
}
