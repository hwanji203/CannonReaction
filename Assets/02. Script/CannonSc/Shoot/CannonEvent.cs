using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonEvent : MonoBehaviour
{
    public event Action shootEvnet;
    public event Action TakeDamageEvent;

    [SerializeField] private float shootFirDelay = 0.3f; // ¼±µô
    [SerializeField] private float shootCool = 0.3f; // ÄðÅ¸ÀÓ
    [SerializeField] private float invincibilityTime = 1f; // ÄðÅ¸ÀÓ

    private Coroutine shootCoroutine;
    private Coroutine takeDamageCoroutine;

    private Animator ani;
    private int shootHash = Animator.StringToHash("Shoot");

    public bool IsShooting { get; private set; } = false;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && shootCoroutine == null)
        {
            IsShooting = true;
            shootCoroutine = StartCoroutine(Shoot());
        }
    }

    public void TakeDamage()
    {
        if (takeDamageCoroutine == null)
        {
            takeDamageCoroutine = StartCoroutine(TakeDamageCo());
        }
    }
    private IEnumerator TakeDamageCo()
    {
        TakeDamageEvent?.Invoke();
        yield return new WaitForSeconds(invincibilityTime);
        takeDamageCoroutine = null;
    }

    private IEnumerator Shoot()
    {
        AniPlay();
        yield return new WaitForSeconds(shootFirDelay);
        shootEvnet?.Invoke();
        yield return new WaitForSeconds(shootCool);
        shootCoroutine = null;
        IsShooting = false;
    }
    private void AniPlay()
    {
        ani.SetTrigger(shootHash);
    }
}
