using UnityEngine;
using System;


public class SlimeHit : MonoBehaviour
{
    protected SlimeHealthSystem healthSystem;

    protected virtual void Awake()
    {
        healthSystem = GetComponent<SlimeHealthSystem>();
    }   

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            healthSystem.TakeDamage(bullet.bulletDamage);
            bullet.gameObject.SetActive(false);
        }
    }

}
