using UnityEngine;

public class SlimeClipEvent : MonoBehaviour
{
    [SerializeField] float fastSpeed = 7.25f;
    [SerializeField] float middleSpeed = 4.5f;
    [SerializeField] float slowSpeed = 0.5f;

    private Rigidbody2D rb;
    private SpreadExp spreadExp;

    private AttackToPlayer attack;
    private SlimeAnimation slimeAnimation;

    public bool CastleAttack { get; set; } = true;

    [SerializeField] int maxSpreadExp;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spreadExp = FindAnyObjectByType<SpreadExp>();
        attack = GetComponent<AttackToPlayer>();
        slimeAnimation = GetComponent<SlimeAnimation>();
    }

    protected virtual void OnEnable()
    {
        rb.linearVelocity = Vector2.up * slowSpeed;
        CastleAttack = true;
    }

    public virtual void CDeadEnd()
    {
        spreadExp.Spread(transform.position, maxSpreadExp);
        gameObject.SetActive(false);
    }

    public void CAttackTiming()
    {
        attack.CheckPlayer();
    }
    public void CAttackEnd()
    {
        if (CastleAttack)
        {
            gameObject.SetActive(false);
        }
        slimeAnimation.IsAttacking = false;
        CastleAttack = true;
    }
    public void CSpeedF()
    {
        rb.linearVelocity = Vector2.up * fastSpeed;
    }
    public void CSpeedM()
    {
        rb.linearVelocity = Vector2.up * middleSpeed;
    }
    public void CSpeedS()
    {
        rb.linearVelocity = Vector2.up * slowSpeed;
    }

}
