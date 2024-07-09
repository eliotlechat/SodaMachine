using System.Collections;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    private Ray ray; 
    public RaycastHit hit; // The object hit by the collision
    
    public GameObject Button { get; private set; } // button of numpad

    [SerializeField]
    private Animator m_Animator;

    [SerializeField]
    private Interface interfaceScript;

    private CollectingTrayScript collectingTrayScript;

    private PlayerScript playerScript;

    private NumpadScript numpadScript;

    private GameObject itemToSpawnInHand;

    private ItemScript itemInHandScript;

    

    private bool hasDrunk = false;
    private bool isDrinking = false;

    private void Start()
    {
        
        playerScript = FindObjectOfType<PlayerScript>();
        numpadScript = FindObjectOfType<NumpadScript>();

        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        if (Application.isFocused)
        {
            ShootRayFromScreenCenter();
            HandleActions();
        }
    }

    
    
    public void ShootRayFromScreenCenter()

    {
        Vector2 ScreenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        ray = Camera.main.ScreenPointToRay(ScreenCenterPoint);

        if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
        {
            ButtonScript buttonScript = hit.transform.GetComponent<ButtonScript>();
            collectingTrayScript = hit.transform.GetComponent<CollectingTrayScript>();

            if (Input.GetButtonDown("Fire1"))
            {
                // if I hit the numpad
                if (buttonScript != null)
                {
                    Button = buttonScript.gameObject;
                    buttonScript.PlayButtonBehavior();
                    numpadScript.DisplayButtonValue();
                    numpadScript.ButtonsValueCombination();

                    return;
                }

                // if I hit the collectingTray
                if (collectingTrayScript != null && collectingTrayScript.itemInCollectingTray == true)  // Si l'objet touché est le collecteur de boisson et qu'il y a un item dedans
                {
                    interfaceScript.DisplayOpenItemText();
                    collectingTrayScript.OutlinerOff();

                    if (collectingTrayScript.itemFalled != null)
                    {
                        Debug.Log("l'item qui va popper dans ma main est : " + collectingTrayScript.itemFalled.name);

                        StartCoroutine(SpawnInHand());

                        if (collectingTrayScript.itemInCollectingTray)
                        {
                            collectingTrayScript.PlayCollectingTrayDoorSound();
                        }

                        // Disabling rb
                        Rigidbody rb = collectingTrayScript.itemFalled.GetComponent<Rigidbody>();

                        rb.isKinematic = true;

                        itemToSpawnInHand = collectingTrayScript.itemFalled;

                        itemInHandScript = itemToSpawnInHand.GetComponent<ItemScript>();

                        itemInHandScript.itemIsInHand = true;

                        collectingTrayScript.itemInCollectingTray = false;

                        return;
                    }
                }
            }
        }
    }

    public void HandleActions()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            // Handle the burping sound
            if (hasDrunk == true && !isDrinking)
            {
       
                playerScript.PlayBurpSound();
                interfaceScript.ClearText();
                return; // Exit to prevent further actions when hasDrunk is true
            }

            // Handle the drinking action
            if (itemInHandScript.itemIsInHand && itemInHandScript.itemIsOpened && !hasDrunk && !isDrinking)

            {
                
                StartCoroutine(HandleDrinking());

                return;
            }

            // Handle the item opening action
            if (itemInHandScript.itemIsInHand == true && itemInHandScript.itemIsOpened == false)
            {
                
                itemInHandScript.Open();
                interfaceScript.DisplayDrinkText();
                itemInHandScript.itemIsOpened = true;
                return;
            }
        }
    }

    private IEnumerator SpawnInHand()
    {
        yield return new WaitForSeconds(0.5f);

        itemToSpawnInHand = collectingTrayScript.itemFalled;

        itemToSpawnInHand.transform.SetParent(transform);
        itemToSpawnInHand.transform.localPosition = Vector3.zero;
        itemToSpawnInHand.transform.localRotation = Quaternion.identity;
        itemToSpawnInHand.transform.localScale = Vector3.one;
        
    }


    private IEnumerator HandleDrinking()
    {
        
        isDrinking = true;
        interfaceScript.ClearText();
        
        m_Animator.SetTrigger("Drinking");
        yield return StartCoroutine(playerScript.PlayDrinkingSound()); // Wait for the drinking sound to finish
        hasDrunk = true;
        
        isDrinking = false;
        interfaceScript.DisplayBurpText();
    }


}