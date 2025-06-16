using UnityEngine;

public class CannonReaction : MonoBehaviour
{
    [SerializeField] private float reactionPower = 18f;
    [SerializeField] public float MyGravityScale = 3;
    private Rigidbody2D rigid;
    private Vector2 reactionDir;

    private CannonEvent cannon;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        cannon = GetComponent<CannonEvent>();
    }
    void Start()
    {
        cannon.shootEvnet += Reaction;
    }

    private void Reaction()
    {
        reactionDir = new Vector2(Mathf.Cos((transform.eulerAngles.z - 90) * Mathf.Deg2Rad), Mathf.Sin((transform.eulerAngles.z - 90) * Mathf.Deg2Rad));
        rigid.linearVelocity /= 3;
        rigid.AddForce(-reactionDir * reactionPower, ForceMode2D.Impulse);
    }

    private void OnDestroy()
    {
        cannon.shootEvnet -= Reaction;
    }
}
