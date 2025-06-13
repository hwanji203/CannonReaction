using UnityEngine;
using static UnityEditor.PlayerSettings;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    private  Rigidbody2D rigid;
    public float zValue { get; set; }

    private Vector3 dir;

    private BoxCollider2D allowedArea;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        allowedArea = GameObject.Find("BulletLiveZone").GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        dir = new Vector3(Mathf.Cos(zValue * Mathf.Deg2Rad), Mathf.Sin(zValue * Mathf.Deg2Rad), 0);
        rigid.linearVelocity = dir * speed;
        Vector2 myPos = transform.position;

        if (!allowedArea.OverlapPoint(myPos))
        {
            gameObject.SetActive(false);
        }
    }

    public abstract void TakeDamage(GameObject enemy);
}
