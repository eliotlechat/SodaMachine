using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Globalization;

public class Machine : MonoBehaviour
{
    public bool hasBeenPaid = false;

    private float canMovementDistance = 0.001f;

    [HideInInspector]
    public bool itemsMovable = false;

    private int input;

    private Transform foundItem;

    public string priceOfSelectedItem;

    [SerializeField]
    private GameObject stock;

    private Numpad numpadScript;
    public CardReader cardReader;

    private List<GameObject> items = new List<GameObject>();

    private void Start()
    {
        numpadScript = FindObjectOfType<Numpad>(); 
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

                // Get price of item and convert float to string
                MachineStack machineStackScript = foundItem.GetComponent<MachineStack>();
                float price = machineStackScript.price;
                priceOfSelectedItem = price.ToString("F2").Replace(",","€ ");

            }

            else
            {
                Debug.LogWarning("MachineStack component not found on the selected item");
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