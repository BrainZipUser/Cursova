using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private Animator animator;

    override protected void Death() 
    {
        animator.SetBool("Fall", true);
        Destroy(gameObject, 3f);
    }
}
