using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    private  Rigidbody2D rigid;
    public float zValue { get; set; }

    private Vector3 dir;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        dir = new Vector3(Mathf.Cos(zValue * Mathf.Deg2Rad), Mathf.Sin(zValue * Mathf.Deg2Rad), 0);
        rigid.linearVelocity = dir * speed;
    }
}
