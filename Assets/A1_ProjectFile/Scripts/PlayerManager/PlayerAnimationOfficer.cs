using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationOfficer : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void PlayIdle()
    {
        animator.SetInteger("State", 0);
    }
    public void PlayRun()
    {
        animator.SetInteger("State", 1);
    }
    
    public void PlayFall()
    {
        animator.SetInteger("State", 2);
    }
}
