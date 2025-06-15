using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ByZombie : BySlime
{
    [SerializeField] private Color baseColor = Color.white;
    [SerializeField] private Color pulseColor = Color.cyan;
    [SerializeField] private float speed = 5f;

    private CannonEvent cannon;
    private SpriteRenderer spriteRen;
    private bool statusEffect = false;
    [SerializeField] private float statusEffectDuration = 3f;

    [SerializeField] private int recoverCount = 5;
    private int nowRecoverCount = 0;

    private CannonTakeDamage takeDam;
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
        takeDam.slimeEffects.Add(this, Effect);
    }

    private IEnumerator StatusEffectDuration()
    {
        cannon.CanShooting = false;
        statusEffect = true;
        yield return new WaitForSeconds(statusEffectDuration);
        Recover();
    }

    private void Recover()
    {
        statusEffect = false;
        cannon.CanShooting = true;
        spriteRen.color = baseColor;
    }

    protected override void Effect()
    {
        StopAllCoroutines();
        StartCoroutine(StatusEffectDuration());
    }
}
