using Unity.VisualScripting;
using UnityEngine;

public class ExpMove : MonoBehaviour
{
    [SerializeField] private float drag = 10;
    [field : SerializeField] public float GoInsidePower { get; set; } = 2.25f;
    [SerializeField] private float addForcePower = 35f;

    private Rigidbody2D rb;

    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer sR;

    private Transform inExpCollecter;
    private GameObject outExpCollecter;

    private ExpEnable expEnable;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        expEnable = GetComponent<ExpEnable>();

        outExpCollecter = GameObject.Find("ExpCollector");
        inExpCollecter = outExpCollecter.transform.GetChild(0).transform;
    }

    private void Update()
    {
        if (rb.linearVelocity.magnitude < 0.5f)
        {
            rb.linearVelocity = Vector2.zero;
        }
        else
        {
            rb.linearVelocity -= rb.linearVelocity * drag * Time.deltaTime;
        }
    }

    private void OnEnable()
    {
        int ran = Random.Range(0, 361);
        sR.sprite = sprites[ran % 10];
        Vector2 dir = new Vector2(Mathf.Cos(ran * Mathf.Deg2Rad), Mathf.Sin(ran * Mathf.Deg2Rad));
        rb.AddForce(dir * addForcePower, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == outExpCollecter)
        {
            Debug.Log("범위 안에 들어감");
            expEnable.IsMoving = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == outExpCollecter)
        {
            rb.AddForce((inExpCollecter.position - transform.position).normalized * GoInsidePower * Time.deltaTime, ForceMode2D.Impulse);
            expEnable.IsMoving = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == outExpCollecter)
        {
            expEnable.IsMoving = true;
        }
    }
}
