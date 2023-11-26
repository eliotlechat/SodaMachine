using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    AudioClip soundButton;

    [SerializeField]
    int inputField;

    [SerializeField]
    private TextMesh textMesh;

    [SerializeField]
    NumpadScript numpadScript;

    public static bool canBeExecuted = true;
    /// private Renderer rend;
    public static bool isCanDropping = false;

    public void ButtonValueDisplay()

    {
        Debug.Log(inputField + " a été touché");
        string inputFieldAsString = inputField.ToString();
        textMesh.text = inputFieldAsString;
        numpadScript.Combination(inputField);
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




}
