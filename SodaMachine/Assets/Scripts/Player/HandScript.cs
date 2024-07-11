using System.Collections;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    [SerializeField]
    private Animator m_Animator;

    private Interface interfaceScript;
    private PlayerScript playerScript;

    private GameObject itemToSpawnInHand;
    private ItemScript itemInHandScript;

    private bool hasDrunk = false;
    private bool isDrinking = false;

    private void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
        interfaceScript = FindObjectOfType<Interface>();
        Cursor.lockState = CursorLockMode.Confined;//Est-ce au bon endroit ???????
    }

    private void Update()
    {
        if (Application.isFocused)
        {
            var raycast = FindObjectOfType<Raycast>();
            raycast.ShootRayFromScreenCenter();
            HandleActions();
        }
    }

    public IEnumerator SpawnInHand(GameObject item)
    {
        yield return new WaitForSeconds(0.5f);

        itemToSpawnInHand = item;
        AttachItemToHand(itemToSpawnInHand);

        itemInHandScript = itemToSpawnInHand.GetComponent<ItemScript>();
        itemInHandScript.itemIsInHand = true;
    }

    private void AttachItemToHand(GameObject item)
    {
        Rigidbody rb = item.GetComponent<Rigidbody>();
        rb.isKinematic = true
            ;
        item.transform.SetParent(transform);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        item.transform.localScale = Vector3.one;
    }

    public void HandleActions()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Handle the burping sound
            if (hasDrunk && !isDrinking)
            {
                HandleBurping();
                return;
            }

            if (itemInHandScript != null)
            {
                if (itemInHandScript.itemIsInHand && itemInHandScript.itemIsOpened && !hasDrunk && !isDrinking)
                {
                    StartCoroutine(HandleDrinking());
                    return;
                }

                if (itemInHandScript.itemIsInHand && !itemInHandScript.itemIsOpened)
                {
                    OpenItemInHand();
                }
            }
        }
    }

    private void HandleBurping()
    {
        playerScript.PlayBurpSound();
        interfaceScript.ClearText();
        StartCoroutine(DestroyAfterDelay(1.0f, itemToSpawnInHand));
    }

    private void OpenItemInHand()
    {
        itemInHandScript.Open();
        interfaceScript.DisplayDrinkText();
        itemInHandScript.itemIsOpened = true;
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

    private IEnumerator DestroyAfterDelay(float delay, GameObject item)
    {
        yield return new WaitForSeconds(delay);
        Destroy(item);
    }
}