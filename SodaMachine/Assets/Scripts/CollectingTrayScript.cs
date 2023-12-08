using UnityEngine;

public class CollectingTrayScript : MonoBehaviour
{
    public bool itemInCollectingTray = false;

    [SerializeField]
    private Material outlineMat;

    [HideInInspector]
    public GameObject itemFalled; // ajout d'une variable pour stocker l'objet qui est dans le collecteur

    AudioSource collectingTrayAudioSource;

    [SerializeField]
    AudioClip collectingTrayDoorSound;

    private void Start()
    {
        collectingTrayAudioSource = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        itemFalled = collision.gameObject;
        Debug.Log(itemFalled.name);
        OutlinerOn();
        itemInCollectingTray = true;
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