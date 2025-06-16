using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class SlimeAnimation : MonoBehaviour
{
    private Rigidbody2D rb;
    protected Animator animator;
    private readonly int startHash = Animator.StringToHash("start");
    private readonly int attackHash = Animator.StringToHash("attack");
    private readonly int hitHash = Animator.StringToHash("hit");
    private readonly int deadHash = Animator.StringToHash("dead");
    private readonly int castleAttack = Animator.StringToHash("castleAttack"); private readonly int reviveHash = Animator.StringToHash("revive");

    public bool IsAttacking { get; set; } = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        IsAttacking = false;
        animator.SetTrigger(startHash);
    }

    public void Attack()
    {
        IsAttacking = true;
        animator.SetTrigger(attackHash);
        animator.SetBool(castleAttack, true);
        rb.linearVelocity = Vector2.zero;
    }
    public void Hit()
    {
        if (!IsAttacking)
        {
            animator.SetTrigger(hitHash);
            rb.linearVelocity = -Vector2.up;
        }
    }
    public void Dead()
    {
        animator.SetTrigger(deadHash); 
        rb.linearVelocity = Vector2.zero;
    }
    public void ReviveAnimation()
    {
        animator.SetTrigger(reviveHash);
    }
}
