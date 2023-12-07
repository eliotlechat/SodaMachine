using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    PlayerScript playerScript;

    [SerializeField]
    AudioClip soundButton;

    AudioSource buttonAudioSource;

    // si le raycast touche le bouton alors, on d�clenche le son bip, et on dit au Numpad quels bouton a �t� touch� 

    private void Start()
    {
        buttonAudioSource = GetComponent<AudioSource>();
        playerScript = GetComponent<PlayerScript>();
    }

    public void PlayButtonSound()
    {
        buttonAudioSource.PlayOneShot(soundButton);
    }
    
    /*
    

    [SerializeField]
    int inputField;

    /*
    public static bool canBeExecuted = true;
    /// private Renderer rend;
    public static bool isCanDropping = false;
    

    public void ButtonValueDisplay()

    {
        Debug.Log(inputField + " a �t� touch�");
        string inputFieldAsString = inputField.ToString();
        textMesh.text = inputFieldAsString;

        // On d�clenche le d�placement des canettes choisi par la combinaison
        numpadScript.CombinationForMovingCans(inputField);
    }

    public void ButtonBehavior()
    {

        if (canBeExecuted == true && isCanDropping == false)
        {
            canBeExecuted = false;
            isCanDropping = true;
            GetComponent<AudioSource>().PlayOneShot(soundButton);

        }
    }
    */



}
