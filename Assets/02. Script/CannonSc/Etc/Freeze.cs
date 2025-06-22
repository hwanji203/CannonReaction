using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Freeze : MonoBehaviour
{
    [SerializeField] private Color baseColor = Color.white;
    [SerializeField] private Color pulseColor = Color.blue;

    [SerializeField] private float statusEffectDuration = 3f;

    [SerializeField] private int recoverCount = 5;
    private int nowRecoverCount = 0;

    private SpriteRenderer ren;

    private CannonEvent cannon;

    [SerializeField] private AudioClip clip;

    private bool statusEffect = false;
    private bool inZone = false;
    private void Awake()
    {
        cannon = GetComponent<CannonEvent>();
        ren = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (statusEffect)
        {
            ren.color = pulseColor;

            if (Keyboard.current.spaceKey.wasPressedThisFrame && !inZone)
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerFreezeZone") && !cannon.IsDamaging)
        {
            StopAllCoroutines();
            StartCoroutine(StatusEffectDuration());
            inZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerFreezeZone"))
        {
            inZone = false;
        }
    }
    private IEnumerator StatusEffectDuration()
    {
        cannon.IsDamaging = true;
        cannon.CanShooting = false;
        statusEffect = true;
        AudioManager.Instance.PlaySFX(clip, 1);
        yield return new WaitForSeconds(statusEffectDuration);
        Recover();
    }

    protected void Recover()
    {
        statusEffect = false;
        cannon.CanShooting = true;
        ren.color = baseColor;
        cannon.IsDamaging = false;
    }
}

