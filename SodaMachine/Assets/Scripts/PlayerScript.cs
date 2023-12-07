using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private HandScript handscript;

    private AudioSource playerAudioSource;

    [SerializeField]
    private AudioClip drinkingSound;

    private Ray ray; // Rayon utilisé pour la détection de collision
    public RaycastHit hit; // L'objet qui a été touché par la collision

    

    private void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
        if (playerAudioSource == null) { playerAudioSource = gameObject.AddComponent<AudioSource>(); }
    }

    private void Update()
    {
        ShootRayFromScreenCenter();
    }

    public void ShootRayFromScreenCenter()

    {
        Vector2 ScreenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        ray = Camera.main.ScreenPointToRay(ScreenCenterPoint);

        if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
        {
            ButtonScript buttonScript = hit.transform.GetComponent<ButtonScript>();
            CollectingTrayScript collectingTrayScript = hit.transform.GetComponent<CollectingTrayScript>();

            if (Input.GetButtonDown("Fire1"))
            {
                // BOUTONS DU PAVE NUMERIQUE
                if (buttonScript != null) // si l'objet touché est le bouton
                {
                    buttonScript.PlayButtonSound();
                }
                // COLLECTEUR DE BOISSON
                if (collectingTrayScript != null && collectingTrayScript.itemInCollectingTray == true)  // Si l'objet touché est le collecteur de boisson et qu'il y a un item dedans
                {
                    
                    collectingTrayScript.OutlinerOff();
                    collectingTrayScript.SpawnInHand();

                    // un son de porte un peu lourde
                    
                }
                //si j'appuie sur le collectingTrayScript est que la canette est dans ma main. 
                // J'ouvre la canette
                // si j'appuie sur le collectingTrayScript est la canette est ouverte
                // handscript.PlayDrinkingCanAnimation();
                //playerAudioSource.PlayOneShot(drinkingSound);
            }
        }
    }
}

/*

[SerializeField]
AudioClip openTabSound;

private StackScript stackScript; // pour référencer le script StackScript qui est attaché à l'objet Stack

[SerializeField]
private NumpadScript numpadScript;

[SerializeField]
Animator mAnimator;

private bool canDrink = false;
private bool canOpen = false;
*/

/*
public void ShootRayFromScreenCenter()
{
    // Si je clique gauche
    if (Input.GetButtonDown("Fire1"))
    {
        if (canDrink == true && canOpen == false)
        {
            mAnimator.SetTrigger("Drinking");
            // Jouer le son de sirotage
            StartCoroutine(PlayDrinkingSound());
            canDrink = false;
        }

        if (canOpen == true && canOpen )
        {
            GetComponent<AudioSource>().PlayOneShot(openTabSound);
            canOpen = false;
            canDrink = true;
        }

        Vector2 ScreenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        ray = Camera.main.ScreenPointToRay(ScreenCenterPoint);

        // Si le rayon touche un objet
        if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
        {
            ButtonScript buttonScript = hit.transform.GetComponent<ButtonScript>();
            CollectingTrayScript collectingTrayScript = hit.transform.GetComponent<CollectingTrayScript>();

            if (buttonScript != null) // si l'objet touché est le bouton
            {
                buttonScript.ButtonValueDisplay(); // On déclenche le comportement du bouton et le bouton va déclencher
                buttonScript.ButtonBehavior();
                //stackScript.moveCan = true;
            }

            // Si l'objet touché est le collecteur de boisson
            if (collectingTrayScript != null)
            {
                //Faire apparaitre la canette dans la main
                collectingTrayScript.SpawnCan();
                canOpen = true;
            }
        }
    }
}

/*
IEnumerator PlayDrinkingSound()
{
    yield return new WaitForSeconds(1.5f);
    GetComponent<AudioSource>().PlayOneShot(drinkingSound);
}
*/