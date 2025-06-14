using UnityEngine;
using System;


public class SlimeEvent : MonoBehaviour
{
    public event Action ApplyDamageEvent;

    private SlimeHealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = GetComponent<SlimeHealthSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<CannonEvent>(out CannonEvent cannon))
        {
            cannon.GiveDamage();
            ApplyDamageEvent?.Invoke();
        }
        else if (collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            healthSystem.TakeDamage(bullet.bulletDamage);
            bullet.gameObject.SetActive(false);
        }
    }

}
