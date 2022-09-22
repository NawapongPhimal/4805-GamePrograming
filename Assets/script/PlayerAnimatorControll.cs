using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorControll : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SetParameter(Vector2 playerVelocity, bool groundState)
    {
        animator.SetFloat("xVelocity", Mathf.Abs(playerVelocity.x));
        animator.SetBool("IsGround", groundState);
    }
}
