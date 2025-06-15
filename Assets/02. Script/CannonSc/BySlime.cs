using UnityEngine;

public abstract class BySlime : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] protected float forcePower = 15;
    protected int dirDeg;
    protected Vector2 dir;
    protected void TakeDamage(string name)
    {
        dirDeg = Random.Range(50, 101);
        dir = new Vector2(Mathf.Cos(dirDeg * Mathf.Deg2Rad), Mathf.Sin(dirDeg * Mathf.Deg2Rad));
        rb.AddForce(dir * forcePower, ForceMode2D.Impulse);
    }

    protected abstract void Effect();
}
