using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class SlimeAnimation : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private readonly int startHash = Animator.StringToHash("start");
    private readonly int attackHash = Animator.StringToHash("attack");
    private readonly int hitHash = Animator.StringToHash("hit");
    private readonly int deadHash = Animator.StringToHash("dead");
    private readonly int castleAttack = Animator.StringToHash("castleAttack");

    public bool IsAttacking { get; set; } = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        animator.SetTrigger(startHash);
        IsAttacking = false;
    }

    public void Attack()
    {
        IsAttacking = true;
        rb.linearVelocity = Vector2.zero;
        animator.SetTrigger(attackHash);
        animator.SetBool(castleAttack, true);
    }
    public void Hit()
    {
        if (!IsAttacking)
        {
            rb.linearVelocity = -Vector2.up;
            animator.SetTrigger(hitHash);
        }
    }
    public void Dead()
    {
        StopAllCoroutines();
        rb.linearVelocity = Vector2.zero;
        animator.SetTrigger(deadHash);
    }
}
