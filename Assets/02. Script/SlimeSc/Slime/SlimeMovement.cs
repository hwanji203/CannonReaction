using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    [SerializeField] float fastSpeed = 7.25f;
    [SerializeField] float middleSpeed = 4.5f;
    [SerializeField] float slowSpeed = 0.5f;

    private Rigidbody2D rb;
    private Animator animator;
    private readonly int startHash = Animator.StringToHash("start");
    private readonly int attackHash = Animator.StringToHash("attack");
    private readonly int hitHash = Animator.StringToHash("hit");
    private readonly int deadHash = Animator.StringToHash("dead");

    private SlimeSpreadExp sSE;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.linearVelocity = Vector2.up * slowSpeed;
        sSE = GetComponent<SlimeSpreadExp>();
    }

    private void OnEnable()
    {
        animator.SetTrigger(startHash);
        SpeedS();
    }

    public void SpeedF()
    {
        rb.linearVelocity = Vector2.up * fastSpeed;
    }
    public void SpeedM()
    {
        rb.linearVelocity = Vector2.up * middleSpeed;
    }
    public void SpeedS()
    {
        rb.linearVelocity = Vector2.up * slowSpeed;
    }

    public void Attack()
    {
        Debug.Log("슬라임 공격 시작");
        rb.linearVelocity = Vector2.zero;
        animator.SetTrigger(attackHash);
    }

    public void AttackEnd()
    {
        Debug.Log("슬라임 공격 끝");
        gameObject.SetActive(false);
    }

    public void Hit()
    {
        Debug.Log("슬라임 맞음");
        rb.linearVelocity = -Vector2.up;
        animator.SetTrigger(hitHash);
    }
    public void Dead()
    {
        Debug.Log("슬라임 죽음");
        animator.SetTrigger(deadHash);
    }
    public void DeadEnd()
    {
        sSE.SpreadExp(transform.position);
    }

    //public void SlimeMove()
    //{
    //    StartCoroutine(MoveCoroutine());
    //}

    //private IEnumerator MoveCoroutine()
    //{
    //    yield return new WaitForSeconds(preDelay);
    //    rb.linearVelocity = Vector2.up * fastSpeed;
    //    yield return new WaitForSeconds(postDelay);
    //    rb.linearVelocity = Vector2.up * slowSpeed;
    //}
}
