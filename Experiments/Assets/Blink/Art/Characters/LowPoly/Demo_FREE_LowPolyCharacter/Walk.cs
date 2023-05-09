using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    private Animator MyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        MyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MyAnimator != null)
        {
            if (MyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !MyAnimator.IsInTransition(0))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    MyAnimator.SetTrigger("Forward");
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    MyAnimator.SetTrigger("Left");
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    MyAnimator.SetTrigger("Backward");
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    MyAnimator.SetTrigger("Right");
                }
                else
                {
                    MyAnimator.SetTrigger("Idle");
                }
            }
        }
    }
}
