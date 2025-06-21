using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    private  Rigidbody2D rigid;
    public float zValue { get; set; }

    private Vector3 dir;

    private BoxCollider2D allowedArea;

    public int hp = 1;
    [field: SerializeField] public int BulletDamage { get; set; } = 1;

    public bool BoreSlime { get; set; } = true;

    private Vector3 bigScale;
    private Vector3 baseScale;
    public bool Bigger { get; set; } = false;

    public float KnockBackPower { get; set; } = 1;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        allowedArea = GameObject.Find("BulletLiveZone").GetComponent<BoxCollider2D>();
        baseScale = transform.localScale;
        bigScale = transform.localScale * 1.35f;

        gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<SlimeHealthSystem>(out SlimeHealthSystem slimeHp))
        {
            if (slimeHp.Hp <= BulletDamage && BoreSlime)
            {
                slimeHp.TakeDamage(BulletDamage);
            }
            else
            {
                slimeHp.GetComponent<SlimeAnimation>().KnockBackPower = KnockBackPower;
                slimeHp.TakeDamage(BulletDamage);
                gameObject.SetActive(false);
            }
        }
    }

    private void OnEnable()
    {
        dir = new Vector3(Mathf.Cos(zValue * Mathf.Deg2Rad), Mathf.Sin(zValue * Mathf.Deg2Rad), 0);
        rigid.linearVelocity = dir * speed;

        if (!allowedArea.OverlapPoint(transform.position))
        {
            gameObject.SetActive(false);
        }
        if (Bigger)
        {
            transform.localScale = bigScale;
        }
        else
        {
            transform.localScale = baseScale;
        }
    }
}
