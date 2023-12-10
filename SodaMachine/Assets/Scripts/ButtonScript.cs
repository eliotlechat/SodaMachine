using UnityEngine;

public class ButtonScript : MonoBehaviour
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

/*

[SerializeField]
int inputField;

/*
public static bool canBeExecuted = true;
/// private Renderer rend;
public static bool isCanDropping = false;

public void ButtonValueDisplay()

{
    Debug.Log(inputField + " a été touché");
    string inputFieldAsString = inputField.ToString();
    textMesh.text = inputFieldAsString;

    // On déclenche le déplacement des canettes choisi par la combinaison
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