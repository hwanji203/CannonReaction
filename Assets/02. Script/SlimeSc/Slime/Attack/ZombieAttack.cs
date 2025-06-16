using UnityEngine;

public class ZombieAttack : AttackToPlayer
{
    protected override void Awake()
    {
        base.Awake();

        cannon = new ByZombie[3];

        cannon[0] = GameObject.Find("Cannon").GetComponent<ByZombie>();
        cannon[1] = GameObject.Find("CannonR").GetComponent<ByZombie>();
        cannon[2] = GameObject.Find("CannonL").GetComponent<ByZombie>();
    }
}
