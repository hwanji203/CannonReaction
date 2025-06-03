using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public event Action shootEvnet;

    public Coroutine ShootCoroutine { get; private set; }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && ShootCoroutine == null)
        {
            ShootCoroutine = StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.12f);
        shootEvnet?.Invoke();
        yield return new WaitForSeconds(0.3f);
        ShootCoroutine = null;
    }
}
