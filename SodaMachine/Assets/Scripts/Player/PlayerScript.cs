using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    /*
     * This script manages the interactions of the player with items
     * It handles picking up, drinking, and destroying of item
     * Additionally, it manages audio feedback for actions such as drinking and burping
     */

    // References to necessary scripts and components
    private Interface interfaceScript;
    private Animator handAnimator;
    private ItemScript itemInHandScript;
    private AudioSource playerAudioSource;

    // Clips audio
    [SerializeField]
    private AudioClip drinkingSound;
    [SerializeField]
    private AudioClip burpSound;

    // Player status
    private bool hasDrunk = false;
    private bool isDrinking = false;
    private bool hasBurped = false;

    private void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
        Transform handTransform = transform.Find("Camera/Hand_R");
        handAnimator = handTransform.GetComponent<Animator>();
        interfaceScript = FindObjectOfType<Interface>();

        if (playerAudioSource == null) { playerAudioSource = gameObject.AddComponent<AudioSource>(); }
    }

    private void Update()
    {
        if (Application.isFocused)
        {
            var raycast = FindObjectOfType<Raycast>();
            raycast.ShootRayFromScreenCenter();
            ProcessItemInteraction();
        }
    }

    public void ProcessItemInteraction()
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
                    OpenItem();
                }
            }
        }
    }

    private void HandleBurping()
    {
        if (!hasBurped)
        {
            hasBurped = true;

            GetComponent<AudioSource>().PlayOneShot(burpSound);
        }
        else
        {
            Debug.Log("Burp sound has already been played");
        }

        interfaceScript.ClearText();

        if (itemInHandScript !=null)
        {
            StartCoroutine(DestroyAfterDelay(1.0f, itemInHandScript.gameObject));
        }
        
    }

    private void OpenItem()
    {
        itemInHandScript.Open();
        interfaceScript.DisplayDrinkText();
        itemInHandScript.itemIsOpened = true;
    }

    private IEnumerator HandleDrinking()
    {
        isDrinking = true;
        interfaceScript.ClearText();

        var m_Animator = GetComponent<Animator>();
        handAnimator.SetTrigger("Drinking");
        yield return StartCoroutine(PlayDrinkingSound()); 

        hasDrunk = true;
        isDrinking = false;
        interfaceScript.DisplayBurpText();
    }

    public IEnumerator SpawnInHand(GameObject itemToSpawn) //itemToSpawn = CollectingTrayScript.itemFalled
    {
        yield return new WaitForSeconds(0.5f);

        // Find Child Hand_R
        Transform handTransform = transform.Find("Camera/Hand_R");

        if (handTransform == null)
        {
            Debug.LogError("Hand_R not found as a child of Camera");
            yield break;
        }

        Rigidbody rb = itemToSpawn.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        itemToSpawn.transform.SetParent(handTransform);
        itemToSpawn.transform.localPosition = Vector3.zero;
        itemToSpawn.transform.localRotation = Quaternion.identity;
        itemToSpawn.transform.localScale = Vector3.one;

        itemInHandScript = itemToSpawn.GetComponent<ItemScript>();
        itemInHandScript.itemIsInHand = true;
    }

    public IEnumerator PlayDrinkingSound()
    {
        Debug.Log("PlayDrinkingSound called");
        yield return new WaitForSeconds(1.5f);
        playerAudioSource.PlayOneShot(drinkingSound);

        yield return new WaitWhile(() => playerAudioSource.isPlaying);
        Debug.Log("Drinking sound finished");
    }

    private IEnumerator DestroyAfterDelay(float delay, GameObject item)
    {
        yield return new WaitForSeconds(delay);
        Destroy(item);
        itemInHandScript = null; // Update reference after destruction
    }


}