using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;

    public void Move( Vector3 moveVector )
    {
        animator.SetFloat( "MoveVelocity", moveVector.magnitude );

        if( moveVector != Vector3.zero )
        {
            animator.gameObject.transform.LookAt( animator.gameObject.transform.position + moveVector);
            Debug.Log(animator.gameObject.transform.rotation);
        }
    }
}
