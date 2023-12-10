using System.Collections.Generic;
using UnityEngine;

public class MachineScript : MonoBehaviour
{
    private float canMovementDistance = 0.001f;

    public bool itemsMovable = false;

    private int input;

    private Transform foundItem;

    [SerializeField]
    private GameObject stock;

    
    NumpadScript numpadScript;

    private List<GameObject> items = new List<GameObject>();

    private void Start()
    {
        numpadScript = FindObjectOfType<NumpadScript>(); // Pourquoi GetComponent ne marche pas 
        input = numpadScript.combination;
        Debug.Log("Le Montant tapé est " + input);
        StackSearch();
    }

    private void Update()
    {
        MoveItems();
    }

    public void StackSearch()
    {
        foreach (Transform item in stock.transform)
        {
            if (item.name == input.ToString())
            {
                foundItem = item;
                Debug.Log("Objet trouvé: " + item.name);
            }
        }
    }

    public void MoveItems()
    {
        if (itemsMovable && foundItem != null)
        {
            foreach (Transform child in foundItem.transform)

            {
                child.transform.Translate(Vector3.forward * canMovementDistance);

                Debug.Log("La stack + " + foundItem + "est en marche ");
            }
        }
    }
}

