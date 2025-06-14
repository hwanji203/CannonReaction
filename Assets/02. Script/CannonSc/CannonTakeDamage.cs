using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonTakeDamage : MonoBehaviour
{
    [SerializeField] private Color baseColor = Color.white;
    [SerializeField] private Color pulseColor = Color.green;
    [SerializeField] private float speed = 5f;

    private CannonEvent cannon;
    private SpriteRenderer spriteRen;
    private bool statusEffect = false;
    [SerializeField] private float statusEffectDuration = 3f;

    private Rigidbody2D rb;
    [SerializeField] private float forcePower = 15;
    private int dirDeg;
    private Vector2 dir;

    [SerializeField] private int recoverCount = 5;
    private int nowRecoverCount = 0;

    private void Awake()
    {
        cannon = GetComponent<CannonEvent>();
        spriteRen = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (statusEffect)
        {
            float t = Mathf.PingPong(Time.time * speed, 1f);
            spriteRen.color = Color.Lerp(baseColor, pulseColor, t);

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                nowRecoverCount++;
                if (nowRecoverCount >= recoverCount)
                {
                    Recover();
                    nowRecoverCount = 0;
                }
            }
        }
    }

    private void Start()
    {
        cannon.TakeDamageEvent += TakeDamage;
    }
    private void TakeDamage()
    {
        cannon.CanShooting = false;
        statusEffect = true;
        dirDeg = Random.Range(50, 101);
        dir = new Vector2(Mathf.Cos(dirDeg * Mathf.Deg2Rad), Mathf.Sin(dirDeg * Mathf.Deg2Rad));
        rb.AddForce(dir * forcePower, ForceMode2D.Impulse);
        StopAllCoroutines();
        StartCoroutine(StatusEffectDuration());
    }

    private IEnumerator StatusEffectDuration()
    {
        yield return new WaitForSeconds(statusEffectDuration);
        Recover();
    }

    private void Recover()
    {
        statusEffect = false;
        cannon.CanShooting = true;
        spriteRen.color = baseColor;
    }
}
