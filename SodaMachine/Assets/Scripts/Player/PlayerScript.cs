using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Interface interfaceScript;

    private Animator handAnimator;
    private ItemScript itemInHandScript;

    private AudioSource playerAudioSource;

    [SerializeField]
    private AudioClip drinkingSound;

    [SerializeField]
    private AudioClip burpSound;

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
            HandleActions();
        }
    }

    public IEnumerator SpawnInHand(GameObject itemToSpawn) //itemToSpawn = CollectingTrayScript.itemFalled
    {
        yield return new WaitForSeconds(0.5f);

        // Find object named Camera
        Transform cameraTransform = transform.Find("Camera");
        if (cameraTransform == null)
        {
            Debug.LogError("Camera not found as a child of " + gameObject.name);
            yield break;
        }

        // Trouver l'objet Hand_R sous Camera
        Transform handTransform = cameraTransform.Find("Hand_R");
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
        PlayBurpSound();
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

        var m_Animator = GetComponent<Animator>();
        handAnimator.SetTrigger("Drinking");
        yield return StartCoroutine(PlayDrinkingSound()); // Wait for the drinking sound to finish

        hasDrunk = true;
        isDrinking = false;
        interfaceScript.DisplayBurpText();
    }

    private IEnumerator DestroyAfterDelay(float delay, GameObject item)
    {
        yield return new WaitForSeconds(delay);
        Destroy(item);
    }

    public IEnumerator PlayDrinkingSound()
    {
        Debug.Log("PlayDrinkingSound called");
        yield return new WaitForSeconds(1.5f);
        playerAudioSource.PlayOneShot(drinkingSound);

        yield return new WaitWhile(() => playerAudioSource.isPlaying);
        Debug.Log("Drinking sound finished");
    }

    public void PlayBurpSound()
    {
        if (!hasBurped)
        {
            hasBurped = true;
            Debug.Log("PlayBurpSound called");

            GetComponent<AudioSource>().PlayOneShot(burpSound);
        }
        else
        {
            Debug.Log("Burp sound has already been played");
        }
    }
}