using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class AttackToPlayer : MonoBehaviour
{
    protected SlimeAnimation slimeAni;
    protected SlimeClipEvent slimeClipEvent;

    protected BySlime[] cannon;
    protected CannonEvent cannonEvent;

    [SerializeField] protected Collider2D attackArea;
    protected Collider2D slimeCollider;

    protected bool isCannonIn = false;
    protected virtual void Awake()
    {
        slimeAni = GetComponent<SlimeAnimation>();
        slimeClipEvent = GetComponent<SlimeClipEvent>();
        slimeCollider = GetComponent<Collider2D>();
    }

    protected virtual void Start()
    {
        cannonEvent = cannon[0].GetComponent<CannonEvent>();
    }
    protected void OnEnable()
    {
        isCannonIn = false;
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (!cannonEvent.IsDamaging)
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
    public void CheckPlayer()
    {
        if (!cannonEvent.IsDamaging)
        {
            for (int i = 0; i < cannon.Length; i++)
            {
                if (attackArea.bounds.Intersects(cannon[i].GetComponent<Collider2D>().bounds))
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
    }
}
