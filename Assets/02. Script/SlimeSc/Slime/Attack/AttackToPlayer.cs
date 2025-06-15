using UnityEngine;

public class AttackToPlayer : MonoBehaviour
{
    private SlimeAnimation slimeAni;
    private SlimeClipEvent slimeClipEvent;

    protected BySlime[] cannon;

    [SerializeField] private Collider2D attackArea;
    private Collider2D slimeCollider;

    private bool isCannonIn = false;
    private void Start()
    {
        slimeAni = GetComponent<SlimeAnimation>();
        slimeClipEvent = GetComponent<SlimeClipEvent>();
        slimeCollider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        isCannonIn = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
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
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
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

    public void CheckPlayer()
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
