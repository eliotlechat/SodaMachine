using UnityEngine;

public class Raycast : MonoBehaviour
{

    public bool raycastOn = true;
    private Ray ray;

    public RaycastHit hit; // The object hit by the collision

    private Numpad numpadScript;
    private Interface interfaceScript;
    private Collector collectorScript;

    public GameObject Numpadbutton { get; private set; } // button of numpad

    
    private void Start()
    {
        numpadScript = FindObjectOfType<Numpad>();
        interfaceScript = FindObjectOfType<Interface>();
        collectorScript = FindObjectOfType<Collector>();
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
        
        Item itemScript = FindObjectOfType<Item>(); 

        if (Input.GetButtonDown("Fire1") && raycastOn)
        {
            NumpadButton numpadButtonScript = hit.transform.GetComponent<NumpadButton>();
            collectorScript = hit.transform.GetComponent<Collector>();

            if (numpadButtonScript != null)
            {
                Numpadbutton = hit.transform.gameObject;  // Met à jour Numpadbutton
                numpadButtonScript.HitNumpadButtonBehavior();
                
                return;
            }

            if (collectorScript != null && collectorScript.itemInCollector)
            {
                collectorScript.HitCollectorDoorBehavior();
            }
        }
    }
}