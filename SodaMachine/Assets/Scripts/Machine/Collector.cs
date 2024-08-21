using UnityEngine;

public class Collector : MonoBehaviour
{
    public bool itemInCollectingTray = false;

    [SerializeField]
    private Material outlineMat;

    [HideInInspector]
    public GameObject itemFalled; // ajout d'une variable pour stocker l'objet qui est dans le collecteur

    private AudioSource collectingTrayAudioSource;

    [SerializeField]
    private AudioClip collectingTrayDoorSound;

    private Numpad numpadScript;

    Interface interfaceScript;

    Machine machineScript;

    private void Start()
    {
        collectingTrayAudioSource = GetComponent<AudioSource>();
        interfaceScript = FindObjectOfType<Interface>();
        machineScript = FindObjectOfType<Machine>();
        numpadScript = FindObjectOfType<Numpad>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        itemFalled = collision.gameObject;
        OutlinerOn();
        itemInCollectingTray = true;
        interfaceScript.ClearText();
        machineScript.cardReader.paymentCardDetected = false;
        // Désactiver tous les boutons du Numpad
        numpadScript.SetButtonsInteractable(false);

    }

    public void HitCollectorDoorBehavior()
    {
        interfaceScript.OpeningText();
        OutlinerOff();
        collectingTrayAudioSource.PlayOneShot(collectingTrayDoorSound);
        // ??? C'est plutot la main qui interroge si il y a quelque chose dans le collector et le fait apparaitre à la main
        var playerScript = FindObjectOfType<Player>();
        playerScript.StartCoroutine(playerScript.SpawnInHand(itemFalled));
        // ??? 
        itemInCollectingTray = false;
    }

    public void OutlinerOn()
    {
        outlineMat.SetFloat("_Scale", 1.02f);
    }

    public void OutlinerOff()
    {
        outlineMat.SetFloat("_Scale", 0f);
    }

    private void OnApplicationQuit() // reset le outline quand je quit/
    {
        OutlinerOff();
    }
}