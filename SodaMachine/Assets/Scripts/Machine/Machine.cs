using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public bool hasBeenPaid = false;

    private float canMovementDistance = 0.001f;

    [HideInInspector]
    public bool itemsMovable = false;

    private int input;

    private Transform foundItem;

    [SerializeField]
    private GameObject stock;

    private Numpad numpadScript;
    public CardReader cardReader;

    private List<GameObject> items = new List<GameObject>();

    private void Start()
    {
        numpadScript = FindObjectOfType<Numpad>(); // Pourquoi GetComponent ne marche pas
        cardReader = FindObjectOfType<CardReader>();
    }

    private void Update()
    {
        MoveItems();
    }

    public void StackSearch()
    {
        input = numpadScript.combination;
        foreach (Transform item in stock.transform)
        {
            if (item.name == input.ToString())
            {
                foundItem = item;

                
                MachineStack machineStackScript = foundItem.GetComponent<MachineStack>();
                float priceOfFoundItem = machineStackScript.price;
                
                
                // après on converti le priceInFloat en priceInString. 
                // et on remplace le . en €
                // et on affiche le montant quand il est selectionné.

                // pour contraindre il faudrait séparer les combinaisons ok et les combinaisons non Ok
            }
        }
    }

    private void MoveItems()
    {
        if (itemsMovable && foundItem != null && hasBeenPaid)
        {
            foreach (Transform child in foundItem.transform)

            {
                child.transform.Translate(Vector3.forward * canMovementDistance);
            }
        }
    }
}