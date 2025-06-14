using UnityEngine;

public class ExpMove : MonoBehaviour
{
    [SerializeField] private float drag = 2f;
    [SerializeField] private float addForcePower = 10f;

    private Rigidbody2D rb;

    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer sR;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (rb.linearVelocity != Vector2.zero)
        {
            rb.linearVelocity -= rb.linearVelocity * drag;
        }
    }

    private void OnEnable()
    {
        int ran = Random.Range(0, 359);
        sR.sprite = sprites[ran % 10];
        Vector2 dir = new Vector2(Mathf.Cos(ran * Mathf.Deg2Rad), Mathf.Sin(ran * Mathf.Deg2Rad));
        rb.AddForce(dir * addForcePower, ForceMode2D.Impulse);
    }
}
