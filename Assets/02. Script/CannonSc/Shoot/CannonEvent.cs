using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonEvent : MonoBehaviour
{
    public event Action shootEvnet;
    public event Action<BySlime> TakeDamageEvent;

    public Rigidbody2D Rb { get; set; }

    [SerializeField] private float shootFirDelay = 0.3f; // ¼±µô
    [field : SerializeField] public float shootCool { get; set; } = 0.3f; // ÄðÅ¸ÀÓ
    public bool IsDamaging { get; set; } = false;

    private Coroutine shootCoroutine;

    private Animator ani;
    private int shootHash = Animator.StringToHash("Shoot");

    public bool IsShooting { get; private set; } = false;

    public bool CanShooting { get; set; } = true;

    private ShootSFX sfx;

    [SerializeField] private GameObject spaceUI;

    public bool Deviled { get; set; } = false;
    public bool Ilaced { get; set; } = false;
    private void Awake()
    {
        ani = GetComponent<Animator>();

        sfx = GetComponent<ShootSFX>();

        spaceUI.SetActive(false);

        Rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!CanShooting) spaceUI.SetActive(true);
        else spaceUI.SetActive(false);

        if (Keyboard.current.spaceKey.wasPressedThisFrame && shootCoroutine == null && CanShooting && !Ilaced)
        {
            IsShooting = true;
            shootCoroutine = StartCoroutine(Shoot());
        }
        if (Keyboard.current.spaceKey.isPressed && shootCoroutine == null && CanShooting && !Ilaced)
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
        if (Deviled)
        {
            transform.Rotate(new Vector3(0, 0, UnityEngine.Random.Range(-45, 45)));
        }
        AniPlay();
        sfx.AudioPlay();
        yield return new WaitForSeconds(shootFirDelay);
        shootEvnet?.Invoke();
        yield return new WaitForSeconds(shootCool);
        shootCoroutine = null;
        IsShooting = false;
    }
    private void AniPlay()
    {
        if (Time.timeScale != 0)
        {
            ani.SetTrigger(shootHash);
        }
    }
}
