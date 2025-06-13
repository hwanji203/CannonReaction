using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    [SerializeField] float fastSpeed = 6.5f;
    [SerializeField] float middleSpeed = 3f;
    [SerializeField] float slowSpeed = 0.1f;

    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.linearVelocity = Vector2.up * slowSpeed;
    }

    private void OnEnable()
    {
        animator.SetTrigger("start");
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

    public void SlimeAttack()
    {
        StopAllCoroutines();
        rb.linearVelocity = Vector2.zero;
        animator.SetTrigger("attack");
    }

    public IEnumerator SlimeApplyDamage()
    {
        yield return new WaitForSeconds(0.45f);
        gameObject.SetActive(false);
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
