using TMPro;
using UnityEditor;
using UnityEngine;

public abstract class BySlime : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] private float forcePower = 15;
    protected int dirDeg;
    protected Vector2 dir;
    protected SpriteRenderer spriteRen;
    protected CannonEvent cannon;
    protected bool statusEffect = false;
    protected CannonTakeDamage takeDam;

    protected float coolDelay;
    protected float coolDefault;

    protected CameraShake camShake;
    private void Awake()
    {
        camShake = FindAnyObjectByType<CameraShake>();

        cannon = GetComponent<CannonEvent>();
        spriteRen = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        takeDam = GetComponent<CannonTakeDamage>();

        coolDefault = cannon.shootCool;
        coolDelay = cannon.shootCool * 2;

        camShake = GetComponent<CameraShake>();
    }
    protected void TakeDamage()
    {
        camShake.Shake(forcePower);
        Jumping();
    }
    private void Start()
    {
        takeDam.slimeEffects.Add(this, Effect);
    }


    protected void Jumping()
    {
        dirDeg = Random.Range(40, 131);
        dir = new Vector2(Mathf.Cos(dirDeg * Mathf.Deg2Rad), Mathf.Sin(dirDeg * Mathf.Deg2Rad));
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(dir * forcePower, ForceMode2D.Impulse);
    }
    protected void Recover()
    {
        MyRecover();
        statusEffect = false;
        spriteRen.color = Color.white;
        cannon.IsDamaging = false;
    }
    protected abstract void Effect();
    protected abstract void MyRecover();
}
