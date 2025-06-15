using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ByMagma : BySlime
{
    [SerializeField] private Color baseColor = Color.white;
    [SerializeField] private Color pulseColor = Color.red;
    [SerializeField] private float speed = 5f;

    [SerializeField] private float intervalSeconds = 1f;

    [SerializeField] private int EffectCount = 3;
    private int nowEffectCount = 0;

    private void Awake()
    {
        cannon = GetComponent<CannonEvent>();
        spriteRen = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        takeDam = GetComponent<CannonTakeDamage>();
    }

    private void Update()
    {
        if (statusEffect)
        {
            float t = Mathf.PingPong(Time.time * speed, intervalSeconds);
            spriteRen.color = Color.Lerp(baseColor, pulseColor, t);
        }
    }
    private IEnumerator StatusEffectDuration()
    {
        yield return new WaitForSeconds(intervalSeconds);
        Jumping();
        if (EffectCount <= nowEffectCount)
        {
            Recover();
        }
        else
        {
            nowEffectCount++;
            StartCoroutine(StatusEffectDuration());
        }
    }

    protected override void MyRecover()
    {
    }

    protected override void Effect()
    {
        TakeDamage();
        nowEffectCount = 0;
        statusEffect = true;
        StartCoroutine(StatusEffectDuration());
    }
}
