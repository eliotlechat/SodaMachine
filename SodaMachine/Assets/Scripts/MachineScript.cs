using System.Collections.Generic;
using UnityEngine;

public class MachineScript : MonoBehaviour
{
    private float canMovementDistance = 0.001f;

    public bool itemsMovable = false;

    public int input;

    private Transform foundItem;

    [SerializeField]
    private GameObject stock;

    private List<GameObject> items = new List<GameObject>();

    private void Start()
    {
        Debug.Log("Le Montant tap� est " + input);
        StackSearch();
        
    }

    private void Update()
    {
        MoveItems();
    }

    public void StackSearch()
    {
        foundItem = null;

        foreach (Transform item in stock.transform)
        {
            if (item.name == input.ToString())
            {
                foundItem = item;
                Debug.Log("Objet trouv�: " + item.name);
            }
        }
    }

    public void MoveItems()
    {
        if (itemsMovable)
        {
            foreach (Transform child in foundItem.transform)

            {
                child.transform.Translate(Vector3.forward * canMovementDistance);

                Debug.Log("La stack + " + foundItem + "est en marche ");
            }
        }
    }
}