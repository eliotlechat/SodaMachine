using System.Collections;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    private Ray ray; // Rayon utilisé pour la détection de collision
    public RaycastHit hit; // L'objet qui a été touché par la collision

    // Ajoutez cette ligne pour stocker le nom du bouton
    public GameObject Button { get; private set; }

    [SerializeField]
    private Animator m_Animator;

    [SerializeField]
    private Interface interfaceScript;

    private CollectingTrayScript collectingTrayScript;

    private PlayerScript playerScript;

    private NumpadScript numpadScript;

    private ItemScript itemScript;

    private bool hasDrunk = false;
    private bool isDrinking = false;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        playerScript = FindObjectOfType<PlayerScript>();
        numpadScript = FindObjectOfType<NumpadScript>();

        Debug.Log("Initial hasDrunk: " + hasDrunk);
        Debug.Log("ItemScript will be initialized later when it's available.");
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
                        itemScript.itemIsInHand = true;
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
            itemScript = FindObjectOfType<ItemScript>();

            // Handle the burping sound
            if (hasDrunk == true && !isDrinking)
            {
                Debug.Log("Playing burp sound");
                playerScript.PlayBurpSound();
                interfaceScript.ClearText();
                return; // Exit to prevent further actions when hasDrunk is true
            }

            // Handle the drinking action
            if (itemScript.itemIsInHand && itemScript.itemIsOpened && !hasDrunk && !isDrinking)

            {
                Debug.Log("Starting drinking process");
                StartCoroutine(HandleDrinking());

                return;
            }

            // Handle the item opening action
            if (itemScript.itemIsInHand == true && itemScript.itemIsOpened == false)
            {
                Debug.Log("Opening item");
                itemScript.Open();
                interfaceScript.DisplayDrinkText();
                itemScript.itemIsOpened = true;
                return;
            }
        }
    }

    private IEnumerator SpawnInHand()
    {
        yield return new WaitForSeconds(0.5f);
        collectingTrayScript.itemFalled.transform.SetParent(transform);
        collectingTrayScript.itemFalled.transform.localPosition = Vector3.zero;
        collectingTrayScript.itemFalled.transform.localRotation = Quaternion.identity;
        collectingTrayScript.itemFalled.transform.localScale = Vector3.one;
        Debug.Log("Ca spawn dans ma main");
    }


    private IEnumerator HandleDrinking()
    {
        
        isDrinking = true;
        interfaceScript.ClearText();
        Debug.Log("Playing drinking sound and animation");
        m_Animator.SetTrigger("Drinking");
        yield return StartCoroutine(playerScript.PlayDrinkingSound()); // Wait for the drinking sound to finish
        hasDrunk = true;
        Debug.Log("hasDrunk set to true");
        isDrinking = false;
        interfaceScript.DisplayBurpText();
    }

    //Debug.Log("Drinking audio finished");
      //  interfaceScript.DisplayBurpText();

}