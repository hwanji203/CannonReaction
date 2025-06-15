using UnityEngine;

public class AttackToPlayer : MonoBehaviour
{
    [SerializeField] private SlimeAnimation slimeAni;
    [SerializeField] private SlimeClipEvent slimeClipEvent;
    private ByZombie[] cannon;
    private Collider2D myCollider;

    private void Start()
    {
        cannon = new ByZombie[3];

        cannon[0] = GameObject.Find("Cannon").GetComponent<ByZombie>();
        cannon[1] = GameObject.Find("CannonR").GetComponent<ByZombie>();
        cannon[2] = GameObject.Find("CannonL").GetComponent<ByZombie>();
        myCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!slimeAni.IsAttacking)
        {
            if (collision.gameObject.CompareTag(cannon[0].gameObject.tag) 
                || collision.gameObject.CompareTag(cannon[1].gameObject.tag)
                || collision.gameObject.CompareTag(cannon[2].gameObject.tag))
            {
                slimeClipEvent.CastleAttack = false;
                slimeAni.Attack();
            }
        }
    }

    public void CheckPlayer()
    {
        for (int i = 0; i < cannon.Length; i++)
        {
            if (myCollider.bounds.Intersects(cannon[i].GetComponent<Collider2D>().bounds))
            {
                for (int j = 0; j < cannon.Length; j++)
                {
                    cannon[j].gameObject.GetComponent<CannonEvent>().TakeDamage(cannon[j]);
                }
                break;
            }
        }
    }
}
