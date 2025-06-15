using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ByZombie : BySlime
{
    [SerializeField] private Color baseColor = Color.white;
    [SerializeField] private Color pulseColor = Color.cyan;
    [SerializeField] private float speed = 5f;

    [SerializeField] private float statusEffectDuration = 3f;

    [SerializeField] private int recoverCount = 5;
    private int nowRecoverCount = 0;


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
    private IEnumerator StatusEffectDuration()
    {
        cannon.CanShooting = false;
        statusEffect = true;
        yield return new WaitForSeconds(statusEffectDuration);
        Recover();
    }

    protected override void MyRecover()
    {
        cannon.CanShooting = true;
    }

    protected override void Effect()
    {
        TakeDamage();
        StartCoroutine(StatusEffectDuration());
    }
}
