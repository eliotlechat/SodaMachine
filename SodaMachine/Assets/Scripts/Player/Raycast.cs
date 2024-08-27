using UnityEngine;

public class Raycast : MonoBehaviour
{

    public bool raycastOn = true;
    private Ray ray;

    public RaycastHit hit; // The object hit by the collision

    private Collector collectorScript;

    public GameObject Numpadbutton { get; private set; } // button of numpad

    
    private void Start()
    {
        collectorScript = FindObjectOfType<Collector>();
        Cursor.lockState = CursorLockMode.Confined;
    }

    
    public void ShootRayFromScreenCenter()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 2.0f);

        if (Physics.Raycast(ray, out hit, 10f))
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