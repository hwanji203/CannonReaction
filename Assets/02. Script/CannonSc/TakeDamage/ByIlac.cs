using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ByIlac : BySlime
{
    [SerializeField] private Color baseColor = Color.white;
    [SerializeField] private Color pulseColor = Color.yellow;
    [SerializeField] private float speed = 20f;

    [SerializeField] private float statusEffectDuration = 4f;

    private float gTemp;
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
        cannon.Ilaced = true;
        gTemp = cannon.Rb.gravityScale;
        cannon.Rb.gravityScale = 0;
        statusEffect = true;
        StartCoroutine(ElectricShockEffect());
        yield return new WaitForSeconds(statusEffectDuration);
        Recover();
    }
    private IEnumerator ElectricShockEffect()
    {
        float timer = 0f;
        float interval = 0.03f;

        while (timer < statusEffectDuration)
        {
            // 랜덤한 방향으로 임펄스 힘 주기
            Vector2 randomDir = Random.insideUnitCircle.normalized;
            float forceAmount = 0.5f; // 충격 세기 (원하는 만큼 조절)

            cannon.Rb.AddForce(randomDir * forceAmount, ForceMode2D.Impulse);

            yield return new WaitForSeconds(interval);
            timer += interval;
        }
    }


    protected override void MyRecover()
    {
        cannon.Ilaced = false;
        cannon.Rb.gravityScale = gTemp;
    }

    protected override void Effect()
    {
        TakeDamage();
        StartCoroutine(StatusEffectDuration());
    }
}
