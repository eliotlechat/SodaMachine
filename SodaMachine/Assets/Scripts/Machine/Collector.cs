using UnityEngine;

public class Collector : MonoBehaviour
{
    public bool itemInCollector = false;

    [SerializeField]
    private Material outlineMat;

    [HideInInspector]
    public GameObject itemFalled; // ajout d'une variable pour stocker l'objet qui est dans le collecteur

    private AudioSource collectorAudioSource;

    [SerializeField]
    private AudioClip collectorDoorSound;

    private Numpad numpadScript;

    private Interface interfaceScript;

    private Machine machineScript;

    private void Start()
    {
        collectorAudioSource = GetComponent<AudioSource>();
        interfaceScript = FindObjectOfType<Interface>();
        machineScript = FindObjectOfType<Machine>();
        numpadScript = FindObjectOfType<Numpad>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        itemFalled = collision.gameObject;
        OutlinerOn();
        itemInCollector = true;
        interfaceScript.ClearText();
        machineScript.cardReader.paymentCardDetected = false;
        // Désactiver tous les boutons du Numpad
        numpadScript.SetButtonsInteractable(false);
    }

    public void HitCollectorDoorBehavior()
    {
        interfaceScript.OpeningText();
        OutlinerOff();
        collectorAudioSource.PlayOneShot(collectorDoorSound);

        var playerScript = FindObjectOfType<Player>();
        playerScript.StartCoroutine(playerScript.SpawnInHand(itemFalled));

        itemInCollector = false;
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