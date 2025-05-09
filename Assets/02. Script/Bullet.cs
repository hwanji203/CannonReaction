using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float rotationPower;
    [SerializeField] private float speed = 20f;
    private  Rigidbody2D rigid;
    public Vector2 MoveDir { get; set; }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (gameObject.activeSelf)
        {
            BallRot();
            Go();
        }
    }
    private void Go()
    {
        rigid.linearVelocity = -MoveDir * speed;
    }

    private void BallRot()
    {
        transform.Rotate(0, 0, rotationPower * Time.deltaTime);
    }
}
