using System.Collections;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    private Ray ray; // Rayon utilis� pour la d�tection de collision
    public RaycastHit hit; // L'objet qui a �t� touch� par la collision

    [SerializeField]
    private Animator m_Animator;

    private CollectingTrayScript collectingTrayScript;

    [SerializeField]
    private PlayerScript playerScript;

    [SerializeField]
    private ItemScript itemScript;

    private bool itemIsInHand = false;
    private bool itemIsOpened = false;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        playerScript = GetComponent<PlayerScript>();
    }

    private void Update()
    {
        ShootRayFromScreenCenter();
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
                if (itemIsInHand == true)
                {
                    m_Animator.SetTrigger("Drinking");
                    StartCoroutine(playerScript.PlayDrinkingSound());
                }

                // SI JE HIT LES BOUTONS DU PAVE NUMERIQUE
                if (buttonScript != null) // si l'objet touch� est le bouton
                {
                    buttonScript.PlayButtonSound();
                }
                // SI JE HIT LE COLLECTEUR DE BOISSON
                if (collectingTrayScript != null && collectingTrayScript.itemInCollectingTray == true)  // Si l'objet touch� est le collecteur de boisson et qu'il y a un item dedans
                {
                    collectingTrayScript.OutlinerOff();

                    if (collectingTrayScript.itemFalled != null)
                    {
                        Debug.Log("l'item qui va popper dans ma main est : " + collectingTrayScript.itemFalled.name);

                        StartCoroutine(SpawnInHand());
                        collectingTrayScript.PlayCollectingTrayDoorSound();
                        // le rb de l'item doit se d�sactiver
                        Rigidbody rb = collectingTrayScript.itemFalled.GetComponent<Rigidbody>();
                        rb.isKinematic = true;
                        itemIsInHand = true;
                    }
                }

                //si je r�appuie est que la canette est dans ma main.
                // J'ouvre la canette
                // si j'appuie sur le collectingTrayScript est la canette est ouverte
                // handscript.PlayDrinkingCanAnimation();
                //playerAudioSource.PlayOneShot(drinkingSound);
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

    public void PlayDrinkingItemAnimation()
    {
        m_Animator.SetTrigger("Drinking");
    }
}