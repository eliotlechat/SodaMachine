using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_L : MonoBehaviour
{
    [SerializeField]
    private Animator m_Animator;

    [SerializeField]
    private NumpadScript numpadScript;

    [SerializeField]
    private GameObject paymentCard;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();

        
    }   

    // Update is called once per frame
    void Update()
    {
        if(numpadScript.isPriceDisplayed == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(HandlePayment());
                

            }
        }
        

    }
    
    private IEnumerator HandlePayment()
    {
        paymentCard.SetActive(true);
        m_Animator.SetTrigger("Pay");

        // Wait the end of animation "Pay"

        yield return new WaitForSeconds(3);

        // The animation is done, desactivate the payment card.
        paymentCard.SetActive(false);
        numpadScript.ResetScreen();
    }




}
