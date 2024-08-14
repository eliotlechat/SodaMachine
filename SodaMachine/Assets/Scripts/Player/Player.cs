using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{


    
    private Interface interfaceRef;
    // FPS Controller
    // Hand

    private Animator handAnimator;
    private Item itemInHandScript;
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
        interfaceRef = FindObjectOfType<Interface>();

        if (playerAudioSource == null) { playerAudioSource = gameObject.AddComponent<AudioSource>(); }
    }

    private void Update()
    {
        if (Application.isFocused)
        {
            var raycast = FindObjectOfType<Raycast>();
            raycast.ShootRayFromScreenCenter();
            DrinkingHandle();
        }
    }

    public void DrinkingHandle()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Handle the burping sound
            if (hasDrunk && !isDrinking)
            {
                Burping();
                return;
            }

            if (itemInHandScript != null)
            {
                if (itemInHandScript.itemIsInHand && itemInHandScript.itemIsOpened && !hasDrunk && !isDrinking)
                {
                    StartCoroutine(Drinking());
                    return;
                }

                if (itemInHandScript.itemIsInHand && !itemInHandScript.itemIsOpened)
                {
                    Opening();
                }
            }
        }
    }

    private void Burping()
    {
        if (!hasBurped)
        {
            hasBurped = true;

            GetComponent<AudioSource>().PlayOneShot(burpSound);
        }


        interfaceRef.ClearText();
        hasDrunk = false;
        isDrinking = false;
        hasBurped = false;

        if (itemInHandScript !=null)
        {
            StartCoroutine(DestroyAfterDelay(1.0f, itemInHandScript.gameObject));
        }
        
    }

    private void Opening()
    {
        itemInHandScript.Open();
        interfaceRef.DrinkingText();
        itemInHandScript.itemIsOpened = true;
    }

    private IEnumerator Drinking()
    {
        isDrinking = true;
        interfaceRef.ClearText();

        var m_Animator = GetComponent<Animator>();
        handAnimator.SetTrigger("Drinking");
        yield return StartCoroutine(PlayDrinkingSound()); 

        hasDrunk = true;
        isDrinking = false;
        interfaceRef.BurpingText();
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

        itemInHandScript = itemToSpawn.GetComponent<Item>();
        itemInHandScript.itemIsInHand = true;
    }

    public IEnumerator PlayDrinkingSound()
    {
        yield return new WaitForSeconds(1.5f);
        playerAudioSource.PlayOneShot(drinkingSound);

        yield return new WaitWhile(() => playerAudioSource.isPlaying);;
    }

    private IEnumerator DestroyAfterDelay(float delay, GameObject item)
    {
        yield return new WaitForSeconds(delay);
        Destroy(item);
        itemInHandScript = null; // Update reference after destruction
       
    }


}