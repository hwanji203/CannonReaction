using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ByIce : BySlime
{
    [SerializeField] private Color baseColor = Color.white;
    [SerializeField] private Color pulseColor = Color.blue;
    [SerializeField] private float speed = 5f;

    [SerializeField] private float statusEffectDuration = 3f;

    private CannonReaction reaction;

    protected override void Awake()
    {
        base.Awake();

        reaction = GetComponent<CannonReaction>();
    }

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
        statusEffect = true;
        reaction.ReactionPower /= 4;
        yield return new WaitForSeconds(statusEffectDuration);
        Recover();
    }

    protected override void MyRecover()
    {
        reaction.ReactionPower *= 4;
    }

    protected override void Effect()
    {
        TakeDamage();
        StartCoroutine(StatusEffectDuration());
    }
}
