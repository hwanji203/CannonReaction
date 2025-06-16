using UnityEngine;

public class ZombieAttack : AttackToPlayer
{
    private ZombieRevive zombieRevive;
    protected override void Awake()
    {
        base.Awake();

        cannon = new ByZombie[3];

        cannon[0] = GameObject.Find("Cannon").GetComponent<ByZombie>();
        cannon[1] = GameObject.Find("CannonR").GetComponent<ByZombie>();
        cannon[2] = GameObject.Find("CannonL").GetComponent<ByZombie>();

        zombieRevive = GetComponent<ZombieRevive>();
    }
    protected override void OnTriggerStay2D(Collider2D collision)
    {
        if (!cannonEvent.IsDamaging && !zombieRevive.IsReviving)
        {
            if (isCannonIn)
            {
                for (int i = 0; i < cannon.Length; i++)
                {
                    if (slimeCollider.bounds.Intersects(cannon[i].GetComponent<Collider2D>().bounds))
                    {
                        for (int j = 0; j < cannon.Length; j++)
                        {
                            cannon[j].gameObject.GetComponent<CannonEvent>().TakeDamage(cannon[j]);
                        }
                        isCannonIn = false;
                        break;
                    }
                }
            }
            if (!slimeAni.IsAttacking)
            {
                if (collision.gameObject.CompareTag("Cannon"))
                {
                    isCannonIn = true;
                    slimeClipEvent.CastleAttack = false;
                    slimeAni.Attack();
                }
            }
        }
    }
}
