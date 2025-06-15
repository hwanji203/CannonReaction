using UnityEngine;

public class AttackToPlayerMain : MonoBehaviour
{
    private SlimeAnimation slimeAni;
    private SlimeClipEvent slimeClipEvent;
    private ByZombie[] cannon;

    private void Awake()
    {
        slimeAni = GetComponent<SlimeAnimation>();
        slimeClipEvent = GetComponent<SlimeClipEvent>();

        cannon = new ByZombie[3];
        cannon[0] = GameObject.Find("Cannon").GetComponent<ByZombie>();
        cannon[1] = GameObject.Find("CannonR").GetComponent<ByZombie>();
        cannon[2] = GameObject.Find("CannonL").GetComponent<ByZombie>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!slimeAni.IsAttacking)
        {
            if (collision.gameObject.CompareTag(cannon[0].gameObject.tag)
                || collision.gameObject.CompareTag(cannon[1].gameObject.tag)
                || collision.gameObject.CompareTag(cannon[2].gameObject.tag))
            {
                slimeClipEvent.CastleAttack = false;
                for (int j = 0; j < cannon.Length; j++)
                {
                    cannon[j].gameObject.GetComponent<CannonEvent>().TakeDamage(cannon[j]);
                }
            }
        }
    }
}
