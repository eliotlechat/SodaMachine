using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // it's used for keep the cursor in window but hide.
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse management
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        

        // for horizontal rotation, it's the parent that rotates, it's why the playerBody
        playerBody.Rotate(Vector3.up * mouseX);

        // for vertical rotation. It's minus instead of plus so that the camera rotation is not reversed. 
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // clamping the x rotation

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


    }
}
