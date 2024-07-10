using UnityEngine;

public class CollectingTrayScript : MonoBehaviour
{
    public bool itemInCollectingTray = false;

    [SerializeField]
    private Material outlineMat;

    [HideInInspector]
    public GameObject itemFalled; // ajout d'une variable pour stocker l'objet qui est dans le collecteur

    private AudioSource collectingTrayAudioSource;

    [SerializeField]
    private AudioClip collectingTrayDoorSound;

    Interface interfaceScript;

    MachineScript machineScript;

    private void Start()
    {
        collectingTrayAudioSource = GetComponent<AudioSource>();
        interfaceScript = FindObjectOfType<Interface>();
        machineScript = FindObjectOfType<MachineScript>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        itemFalled = collision.gameObject;
        OutlinerOn();
        itemInCollectingTray = true;
        interfaceScript.ClearText();

        machineScript.cardReader.paymentCardDetected = false;

    }

    public void PlayCollectingTrayDoorSound()
    {
        collectingTrayAudioSource.PlayOneShot(collectingTrayDoorSound);
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