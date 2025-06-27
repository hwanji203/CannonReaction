using UnityEngine;

public class ZombieAttack : AttackToPlayer
{
    private ZombieRevive zombieRevive;
    protected override void Awake()
    {
        base.Awake();

        cannon = new ByZombie[3];

        GameObject cannons = GameObject.Find("Cannons");

        for (int i = 0; i < cannon.Length; i++)
        {
            cannon[i] = cannons.transform.GetChild(i).GetComponent<ByZombie>();
        }

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
                    Debug.Log("플레이어한테 맞아서 ");
                    isCannonIn = true;
                    slimeClipEvent.CastleAttack = false;
                    slimeAni.Attack();
                }
            }
        }
    }
}
