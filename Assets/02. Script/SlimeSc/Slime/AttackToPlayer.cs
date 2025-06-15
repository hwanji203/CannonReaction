using UnityEngine;

public class AttackToPlayer : MonoBehaviour
{
    private SlimeAnimation slimeAni;
    private SlimeClipEvent slimeClipEvent;
    private ByZombie[] cannon;
    [SerializeField] private Collider2D attackArea;
    private Collider2D slimeCollider;

    private bool isCannonIn = false;

    private void Start()
    {
        slimeAni = GetComponent<SlimeAnimation>();
        slimeClipEvent = GetComponent<SlimeClipEvent>();

        cannon = new ByZombie[3];

        cannon[0] = GameObject.Find("Cannon").GetComponent<ByZombie>();
        cannon[1] = GameObject.Find("CannonR").GetComponent<ByZombie>();
        cannon[2] = GameObject.Find("CannonL").GetComponent<ByZombie>();
        slimeCollider = GetComponent<Collider2D>();
    }

    private void Update()
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
            if (collision.gameObject.CompareTag(cannon[0].gameObject.tag) 
                || collision.gameObject.CompareTag(cannon[1].gameObject.tag)
                || collision.gameObject.CompareTag(cannon[2].gameObject.tag))
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
