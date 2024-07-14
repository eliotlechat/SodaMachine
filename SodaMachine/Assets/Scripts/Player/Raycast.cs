using UnityEngine;

public class Raycast : MonoBehaviour
{
    
    private Ray ray;

    public RaycastHit hit; // The object hit by the collision

    private NumpadScript numpadScript;
    private Interface interfaceScript;
    private CollectingTrayScript collectingTrayScript;

    public GameObject button { get; private set; } // button of numpad

    
    private void Start()
    {
        numpadScript = FindObjectOfType<NumpadScript>();
        interfaceScript = FindObjectOfType<Interface>();
        collectingTrayScript = FindObjectOfType<CollectingTrayScript>();
        Cursor.lockState = CursorLockMode.Confined;
    }

    
    public void ShootRayFromScreenCenter()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        
        if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
        {
            
            HandleRaycastHit();
        }
    }

    private void HandleRaycastHit()
    {
        ButtonScript buttonScript = hit.transform.GetComponent<ButtonScript>();
        collectingTrayScript = hit.transform.GetComponent<CollectingTrayScript>();

        if (Input.GetButtonDown("Fire1"))
        {
            if (buttonScript != null)
            {
                HandleButtonHit(buttonScript);
                return;
            }

            if (collectingTrayScript != null && collectingTrayScript.itemInCollectingTray)
            {
                HandleCollectingTrayHit();
            }
        }
    }

    private void HandleButtonHit(ButtonScript buttonScript)
    {
        button = buttonScript.gameObject;
        buttonScript.PlayButtonBehavior();
        numpadScript.DisplayButtonValue();
        numpadScript.ButtonsValueCombination();
    }

    private void HandleCollectingTrayHit()
    {
        interfaceScript.DisplayOpenItemText();
        collectingTrayScript.OutlinerOff();

        if (collectingTrayScript.itemFalled != null)
        {
            Debug.Log("l'item qui va popper dans ma main est : " + collectingTrayScript.itemFalled.name);

            var playerScript = FindObjectOfType<PlayerScript>();
            playerScript.StartCoroutine(playerScript.SpawnInHand(collectingTrayScript.itemFalled));

            collectingTrayScript.PlayCollectingTrayDoorSound();
            collectingTrayScript.itemInCollectingTray = false;
        }
    }
}