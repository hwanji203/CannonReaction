using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonEvent : MonoBehaviour
{
    public event Action shootEvnet;
    public event Action<BySlime> TakeDamageEvent;

    [SerializeField] private float shootFirDelay = 0.3f; // ¼±µô
    [field : SerializeField] public float shootCool { get; set; } = 0.3f; // ÄðÅ¸ÀÓ
    public bool IsDamaging { get; set; } = false;

    private Coroutine shootCoroutine;

    private Animator ani;
    private int shootHash = Animator.StringToHash("Shoot");

    public bool IsShooting { get; private set; } = false;

    public bool CanShooting { get; set; } = true;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && shootCoroutine == null && CanShooting)
        {
            IsShooting = true;
            shootCoroutine = StartCoroutine(Shoot());
        }
    }
    public void TakeDamage(BySlime name)
    {
        if (!IsDamaging)
        {
            TakeDamageEvent?.Invoke(name);
        }
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
