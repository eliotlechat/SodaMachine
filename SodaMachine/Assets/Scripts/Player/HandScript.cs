using System.Collections;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    
    private Animator m_Animator;

    private Interface interfaceScript;
    private PlayerScript playerScript;

    private ItemScript itemInHandScript;

    private bool hasDrunk = false;
    private bool isDrinking = false;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        playerScript = FindObjectOfType<PlayerScript>();
        interfaceScript = FindObjectOfType<Interface>();
        
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

    public IEnumerator SpawnInHand(GameObject itemToSpawn) //itemToSpawn = CollectingTrayScript.itemFalled
    {
        yield return new WaitForSeconds(0.5f);

        
        
        Rigidbody rb = itemToSpawn.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        itemToSpawn.transform.SetParent(transform);
        itemToSpawn.transform.localPosition = Vector3.zero;
        itemToSpawn.transform.localRotation = Quaternion.identity;
        itemToSpawn.transform.localScale = Vector3.one;

        itemInHandScript = itemToSpawn.GetComponent<ItemScript>();
        itemInHandScript.itemIsInHand = true;
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
        StartCoroutine(DestroyAfterDelay(1.0f, itemInHandScript.gameObject));
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