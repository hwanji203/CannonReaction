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

    public bool FirstMove = true;

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
        if (rb.linearVelocity.magnitude < 0.5f && FirstMove)
        {
            rb.linearVelocity = Vector2.zero;
        }
        else
        {
            rb.linearVelocity -= rb.linearVelocity * drag * Time.deltaTime;
            FirstMove = false;
        }
    }

    private void OnEnable()
    {
        FirstMove = true;
        int ran = Random.Range(0, 361);
        sR.sprite = sprites[ran % 10];
        Vector2 dir = new Vector2(Mathf.Cos(ran * Mathf.Deg2Rad), Mathf.Sin(ran * Mathf.Deg2Rad));
        rb.AddForce(dir * addForcePower, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == outExpCollecter)
        {
            expEnable.IsMoving = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == outExpCollecter)
        {
            rb.AddForce((inExpCollecter.position - transform.position).normalized * GoInsidePower * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == outExpCollecter)
        {
            expEnable.IsMoving = false;
        }
    }
}
