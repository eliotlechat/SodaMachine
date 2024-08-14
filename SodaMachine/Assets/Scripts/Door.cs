using System.Collections;
using UnityEngine;



public class Door : MonoBehaviour
{
    public Transform door; // Référence à l'objet de la porte
    public Vector3 rotationAngle = new Vector3(0, 90, 0); // L'angle de rotation souhaité
    public float rotationSpeed = 2f; // La vitesse de la rotation

    private bool isRotating = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    private void Start()
    {
        if (door == null)
        {
            door = transform; // Si aucune porte n'est assignée, utiliser l'objet auquel ce script est attaché
        }
        initialRotation = door.rotation;
        targetRotation = Quaternion.Euler(door.eulerAngles + rotationAngle);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isRotating)
        {
            isRotating = true;
            StartCoroutine(RotateDoor());
        }
    }

    private IEnumerator RotateDoor()
    {
        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime * rotationSpeed;
            door.rotation = Quaternion.Slerp(initialRotation, targetRotation, t);
            yield return null;
        }
        door.rotation = targetRotation;
        isRotating = false;
    }
}

/*
 * public class Door : MonoBehaviour
{
    public Transform door; // Référence à l'objet de la porte
    public Vector3 rotationAngle = new Vector3(0, -105, 0); // L'angle de rotation souhaité

    private void OnTriggerEnter(Collider other)
    {
        door.Rotate(rotationAngle);
    }
}
*/