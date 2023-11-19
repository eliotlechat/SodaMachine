using UnityEngine;

public class RowScript : MonoBehaviour
{
    public GameObject[] itemsList; // Le tableau de prefabs � instancier
    float distanceInterval = 0.1f; // distance des intervalles entre chaque instance
    int numberOfInstances = 4; // le nombre d'instance � cr�er. 
    [SerializeField]
    private Transform stack;

    // Start is called before the first frame update
    void Start()
    {
        if (itemsList.Length == 0)
        {
            Debug.LogError("Aucun prefab est assign� dans itemsList");
            return;
        }

        // Pour chaque enfant de Row
        int stackIndex = 0;
        foreach (Transform stack in transform)
        {
            // V�rifiez si nous avons un prefab pour ce stack
            if (stackIndex >= itemsList.Length)
            {
                Debug.LogError("Pas de prefab pour le stack " + stack.name);
                continue;
            }

            GameObject item = itemsList[stackIndex]; // Le prefab � instancier pour ce stack

            // Appeler la m�thode pour instancier les objets
            InstantiateObjects(stack, item);

            stackIndex++;
        }
    }


    void InstantiateObjects(Transform stack, GameObject item)
    {
        // Instantier le nombre d'objets d�finis, � un intervalle d'une distance donn�e, avec une rotation al�atoire sur l'axe des y
        for (int i = 0; i < numberOfInstances; i++)
        {
            Vector3 newPosition = stack.position - new Vector3(0, 0, distanceInterval * i);
            Quaternion newRotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
            GameObject instance = Instantiate(item, newPosition, newRotation);
            instance.transform.parent = stack;

        }
    }

    // On va peut etre cr�er un script StackScript qui permet de relier les boutons aux stacks.
    // Et faire une classe qui quand j'appuie sur le bouton, cela fait avancer la m�thode MoveCans.
    // M�thode pour d�placer les canettes d'une stack
    public void MoveCans()
    {
        // Pour chaque enfant du stack
        foreach (Transform canette in stack)
        {
            if(canette != transform)
            { 
                // D�placer la canette de 0.1f
                canette.position = canette.position + new Vector3(0, 0, 0.1f);
            }
            

        }
    }
    // Ensuite ce qu'il faut, c'est d'assigner un stack par bouton, 
    // et lorsque j'appuie sur un bouton cela choisi le stack qui correspond et d�clenche MoveCans()


}


