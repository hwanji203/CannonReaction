using UnityEngine;
using System;

public class CannonReaction : MonoBehaviour
{
    [SerializeField] private float reactionPower = 35f;
    [SerializeField] private float myGravityScale = 3;
    private Rigidbody2D rigid;
    private Vector2 reactionDir;

    private Player player;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        player = GetComponent<Player>();
        rigid.gravityScale = myGravityScale;

        player.shootEvnet += Reaction;
    }

    private void Reaction()
    {
        reactionDir = new Vector2(Mathf.Cos((transform.eulerAngles.z - 90) * Mathf.Deg2Rad), Mathf.Sin((transform.eulerAngles.z - 90) * Mathf.Deg2Rad));
        rigid.linearVelocity /= 3;
        rigid.AddForce(-reactionDir * reactionPower, ForceMode2D.Impulse);
    }
}
