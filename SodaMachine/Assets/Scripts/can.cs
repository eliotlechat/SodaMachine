using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanScript : MonoBehaviour
{
    public float speed = 1.0f;
    public float delay = 2.0f; // Ajoutez cette ligne
    public bool canMove = false;

    public void StartMoving()
    {
        StartCoroutine(DelayedMovement());
    }

    IEnumerator DelayedMovement()
    {
        yield return new WaitForSeconds(delay);
        canMove = true;
    }

    void Update()
    {
        if (canMove)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
}