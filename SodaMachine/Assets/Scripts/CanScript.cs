using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanScript : MonoBehaviour
{
    public AudioClip fallSound;
    
    //private Vector3 initialPosition;
    //private Quaternion initialRotation;

    private void Start()
    {
        //initialPosition = transform.position;
        //initialRotation = transform.rotation; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "collectingTray")
        {
            ButtonBehaviorScript.isCanDropping = false;
            ButtonBehaviorScript.canBeExecuted = true;
            Debug.Log(gameObject.name + " est tombé dans le collecteur de boisson");
            GetComponent<AudioSource>().PlayOneShot(fallSound);
            //StartCoroutine(ResetCan());
        }
    }
    //IEnumerator ResetCan()
    //{
    //    // reset la position et la rotation de la canette
    //    yield return new WaitForSeconds(2); 
    //    transform.position = initialPosition;
    //    transform.rotation = initialRotation;
        
    //}
}

