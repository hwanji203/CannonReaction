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

    [SerializeField] private int damage = 1;
    private CastleHealthSystem castle;

    [SerializeField] private AudioClip attackClip;
    [SerializeField] private AudioClip deadClip;

    private RecordSystem record;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spreadExp = FindAnyObjectByType<SpreadExp>();
        attack = GetComponent<AttackToPlayer>();
        slimeAnimation = GetComponent<SlimeAnimation>();
        castle = FindAnyObjectByType<CastleHealthSystem>();
        record = FindAnyObjectByType<RecordSystem>();
    }

    protected virtual void OnEnable()
    {
        rb.linearVelocity = Vector2.up * slowSpeed;
        CastleAttack = true;
    }

    public virtual void CDeadEnd()
    {
        spreadExp.Spread(transform.position, maxSpreadExp);
        record.KillCountPlus();
        gameObject.SetActive(false);
    }
    public virtual void CDeadStart()
    {
        rb.linearVelocity = Vector2.zero;
        AudioManager.Instance.PlaySFX(deadClip, 1);
    }

    public void CAudio()
    {
        AudioManager.Instance.PlaySFX(attackClip, 2f);
    }

    public void CAttackTiming()
    {
        if (CastleAttack)
        {
            GiveDamage();
        }
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
    public void CKnockBack()
    {
        slimeAnimation.KnockBack();
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
    public void GiveDamage()
    {
        castle.GetDamage(damage);
    }
}
