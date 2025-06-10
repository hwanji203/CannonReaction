using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public event Action shootEvnet;

    [SerializeField] private float shootFirDelay = 0.3f; // ¼±µô
    [SerializeField] private float shootCool = 0.3f; // ÄðÅ¸ÀÓ

    public Coroutine ShootCoroutine { get; private set; }

    private Animator ani;
    private int shootHash = Animator.StringToHash("Shoot");

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && ShootCoroutine == null)
        {
            ShootCoroutine = StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        AniPlay();
        yield return new WaitForSeconds(shootFirDelay);
        shootEvnet?.Invoke();
        yield return new WaitForSeconds(shootCool);
        ShootCoroutine = null;
    }
    private void AniPlay()
    {
        ani.SetTrigger(shootHash);
    }
}
