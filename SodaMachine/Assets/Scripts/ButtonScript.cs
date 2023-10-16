using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private raycast playerCameraRaycast;
    private CanScript canScript;
    public AudioSource source;
    public AudioClip clip;


    void Start()
    {
        playerCameraRaycast = GameObject.Find("PlayerCamera").GetComponent<raycast>();
        canScript = GameObject.Find("can").GetComponent<CanScript>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerCameraRaycast.Raycast();
            canScript.StartMoving();
            source.PlayOneShot(clip);
        }
    }
}
