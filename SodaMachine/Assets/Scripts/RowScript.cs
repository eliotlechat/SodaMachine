using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RowScript : MonoBehaviour
{
    public GameObject[] itemsList; // Le tableau de prefabs à instancier
    float distanceInterval = 0.1f; // distance des intervalles entre chaque instance
    int numberOfInstances = 4; // le nombre d'instance à créer. 

    // Start is called before the first frame update
    void Start()
    {
        if (itemsList.Length == 0)
        {
            Debug.LogError("Aucun prefab est assigné dans itemsList");
            return;
        }

        // Pour chaque enfant de Row
        int stackIndex = 0;
        foreach (Transform stack in transform)
        {
            // Vérifiez si nous avons un prefab pour ce stack
            if (stackIndex >= itemsList.Length)
            {
                Debug.LogError("Pas de prefab pour le stack " + stack.name);
                continue;
            }

            GameObject item = itemsList[stackIndex]; // Le prefab à instancier pour ce stack

            // Appeler la méthode pour instancier les objets
            InstantiateObjects(stack, item);

            stackIndex++;
        }
    }

    
    void InstantiateObjects(Transform stack, GameObject item)
    {
        // Instantier le nombre d'objets définis, à un intervalle d'une distance donnée, avec une rotation aléatoire sur l'axe des y
        for (int i = 0; i < numberOfInstances; i++)
        {
            Vector3 newPosition = stack.position - new Vector3(0, 0, distanceInterval * i);
            Quaternion newRotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
            GameObject instance = Instantiate(item, newPosition, newRotation);
            instance.transform.parent = stack;

        }
    }
    // Méthode pour déplacer les canettes d'une stack
    public void MoveCans(Transform stack)
    {
        // Pour chaque enfant du stack
        foreach (Transform canette in stack)
        {
            // Parcourir chaque canette dans le stack
            foreach (Transform can in stack)
            {
                // Déplacer la canette de 0.1f
                can.position = can.position + new Vector3(0, 0, 1f);
            }
        }
    }
    // Ensuite ce qu'il faut, c'est d'assigner un stack par bouton, 
    // et lorsque j'appuie sur un bouton cela choisi le stack qui correspond et déclenche MoveCans()


}



