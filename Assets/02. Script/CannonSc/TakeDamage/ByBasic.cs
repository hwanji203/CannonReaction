    using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ByBasic : BySlime
{
    [SerializeField] private Color baseColor = Color.white;
    [SerializeField] private Color pulseColor = Color.green;
    [SerializeField] private float speed = 5f;

    [SerializeField] private float statusEffectDuration = 3f;

    private void Update()
    {
        if (statusEffect)
        {
            float t = Mathf.PingPong(Time.time * speed, 1f);
            spriteRen.color = Color.Lerp(baseColor, pulseColor, t);
        }
    }
    private IEnumerator StatusEffectDuration()
    {
        cannon.shootCool = coolDelay;
        statusEffect = true;
        yield return new WaitForSeconds(statusEffectDuration);
        Recover();
    }
    protected override void MyRecover()
    {
        cannon.shootCool = coolDefault;
    }
    protected override void Effect()
    {
        TakeDamage();
        StartCoroutine(StatusEffectDuration());
    }
}
