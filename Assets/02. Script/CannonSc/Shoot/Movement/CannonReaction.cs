using UnityEngine;

public class CannonReaction : MonoBehaviour
{
    [SerializeField] public float ReactionPower = 12.75f;
    [SerializeField] public float MyGravityScale = 3;
    private Rigidbody2D rigid;
    private Vector2 reactionDir;

    [SerializeField] private float maxFallSpeed = -10f; // 음수로 설정 (하강이기 때문)
    private CannonEvent cannon;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        cannon = GetComponent<CannonEvent>();

        rigid.gravityScale = MyGravityScale;
    }
    void Start()
    {
        cannon.shootEvnet += Reaction;
    }

    private void FixedUpdate()
    {
        Vector2 vel = rigid.linearVelocity;

        // 낙하 속도 제한
        if (vel.y < maxFallSpeed)
        {
            vel.y = maxFallSpeed;
            rigid.linearVelocity = vel;
        }
    }

    private void Reaction()
    {
        reactionDir = new Vector2(Mathf.Cos((transform.eulerAngles.z - 90) * Mathf.Deg2Rad), Mathf.Sin((transform.eulerAngles.z - 90) * Mathf.Deg2Rad));
        rigid.linearVelocity /= 3;
        rigid.AddForce(-reactionDir * ReactionPower, ForceMode2D.Impulse);
    }

    private void OnDestroy()
    {
        cannon.shootEvnet -= Reaction;
    }
}
