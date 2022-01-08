using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;
    private Transform animTransform;

    public void Move( Vector3 moveVector )
    {
        animator.SetFloat( "MoveVelocity", moveVector.magnitude );

        if( moveVector != Vector3.zero )
        {
            Vector3 actualDirection = SnowmanMath.VectorApproach( animator.transform.forward, moveVector, 0.15f, Time.deltaTime );
            animator.transform.LookAt( animator.transform.position + actualDirection );
        }
    }
}
