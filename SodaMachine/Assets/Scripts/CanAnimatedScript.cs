using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanAnimatedScript : MonoBehaviour
{
    Animator mAnimator;
   



    // Start is called before the first frame update
    void Start()
    {
        
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CanAnimationStart()
    {
        mAnimator.SetTrigger("Drinking");
    }


}