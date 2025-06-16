using UnityEngine;

public class ZombieHit : SlimeHit
{
    private ZombieRevive zombieRevive;

    protected override void Awake()
    {
        base.Awake();
        zombieRevive = GetComponent<ZombieRevive>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!zombieRevive.IsReviving)
        {
            if (collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
            {
                healthSystem.TakeDamage(bullet.bulletDamage);
                bullet.gameObject.SetActive(false);
            }
        }
    }
}
