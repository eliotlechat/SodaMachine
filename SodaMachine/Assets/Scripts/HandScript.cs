using UnityEngine;
using UnityEngine.XR;

public class HandScript : MonoBehaviour
{
    private Animator m_Animator;

    

    // Start is called before the first frame update
    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        
    }

    public void PlayDrinkingItemAnimation()
    {
        m_Animator.SetTrigger("Drinking");
    }

  
}