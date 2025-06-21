using UnityEngine;

public class ZombieHit : SlimeHit
{
    private ZombieRevive zombieRevive;
    private Collider2D coll;

    protected override void Awake()
    {
        base.Awake();
        zombieRevive = GetComponent<ZombieRevive>();
        coll = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (zombieRevive.IsReviving) coll.enabled = false;
        else coll.enabled = true;
    }
}
