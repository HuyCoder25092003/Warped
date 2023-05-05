using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : AnimationBase
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
            animator.SetBool("Run", true);
        else animator.SetBool("Run", false);

        if (Input.GetKeyDown(KeyCode.R))
            animator.SetBool("Shoot", true);
        else animator.SetBool("Shoot", false);

        if (Input.GetKey(KeyCode.Space))
            animator.SetTrigger("Jump");
    }
}
