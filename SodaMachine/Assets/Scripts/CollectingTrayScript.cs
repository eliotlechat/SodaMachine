using UnityEngine;

public class CollectingTrayScript : MonoBehaviour
{

    public bool itemInCollectingTray = false;

    [SerializeField]
    private Material outlineMat;

    
    public GameObject itemFalled; // ajout d'une variable pour stocker l'objet qui est dans le collecteur

    [SerializeField]
    private GameObject hand;



    private void OnCollisionEnter(Collision collision)
    {
        itemFalled = collision.gameObject;
        OutlinerOn();
        itemInCollectingTray = true;
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

    public void SpawnInHand()
    {
        if (itemFalled != null)
        {
            itemFalled.transform.SetParent(hand.transform);
            itemFalled.transform.localPosition = Vector3.zero;
            itemFalled.transform.localRotation = Quaternion.identity;
            itemFalled.transform.localScale = Vector3.one;
        }

    }

}