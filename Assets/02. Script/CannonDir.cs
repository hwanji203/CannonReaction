using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonDir : MonoBehaviour
{
    [SerializeField] private float reboundPower = 35f;
    [SerializeField] private float myGravityScale = 3;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject cannonHitbox;
    [SerializeField] private float rotatePower = 0.8f;
    private Vector3 moveDir;
    private Vector3 shootDir;
    private Rigidbody2D rigid;
    private Transform fireSpot;
    private Coroutine shootCorout;
    private AniRight aniR;
    private AniLeft aniL;

    private GameObject[] bulletPool;
    private readonly int bulletPoolSize = 5;
    private Transform bulletPoolPa;

    private Transform parPoolPa;
    [SerializeField] private ParticleSystem smokePar;
    [SerializeField] private ParticleSystem firePar;
    private ParticleSystem[] smokeParPool;
    private ParticleSystem[] fireParPool;
    private readonly int parPoolSize = 5;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        aniL = GameObject.FindAnyObjectByType<AniLeft>();
        aniR = GameObject.FindAnyObjectByType<AniRight>();
        fireSpot = GameObject.Find("FireSpotR").transform;
    }
    private void Start()
    {
        moveDir = new Vector3(0, 0, 0);
        rigid.gravityScale = myGravityScale;

        bulletPoolPa = GameObject.Find("BulletPool").transform;
        bulletPool = new GameObject[bulletPoolSize];
        for (int i = 0; i < bulletPoolSize; i++)
        {
            bulletPool[i] = Instantiate(bulletPrefab, bulletPoolPa);
            bulletPool[i].gameObject.SetActive(false);
        }

        parPoolPa = GameObject.Find("ParPoolPa").transform;
        PoolMake(parPoolPa, smokePar, ref smokeParPool, parPoolSize);
        PoolMake(parPoolPa, firePar, ref fireParPool, parPoolSize);
    }

    private void PoolMake(Transform father, ParticleSystem particle, ref ParticleSystem[] parPool, int size)
    {
        parPool = new ParticleSystem[size];
        for (int i = 0; i < size; i++)
        {
            parPool[i] = Instantiate(particle, father);
        }
    }

    private void Update()
    {
        CanShoot();
        if (shootCorout == null)
        {
            Rot();
        }
    }
    private void CanShoot()
    {
        if (Input.GetMouseButtonUp(0) || Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (shootCorout == null)
            {
                shootCorout = StartCoroutine(Shoot());
            }
        }
    }
    private IEnumerator Shoot()
    {
        SpShoot();
        yield return new WaitForSeconds(0.2f);
        rigid.linearVelocity /= 3;
        Fire();
        ParPlay(smokeParPool);
        ParPlay(fireParPool);
        rigid.AddForce( shootDir * reboundPower, ForceMode2D.Impulse);
        shootCorout = null;
    }

    private void Fire()
    {
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullet = bulletPool[i];
            if (!bullet.activeSelf)
            {
                bullet.SetActive(true);
                bullet.transform.position = fireSpot.position;
                bullet.GetComponent<Bullet>().MoveDir = ShootDir;
                break;
            }
        }
    }

    private void ParPlay(ParticleSystem[] parPool)
    {
        for (int i = 0; i < parPool.Length; i++)
        {
            GameObject par = parPool[i].gameObject;
            if (!par.activeSelf)
            {
                par.gameObject.SetActive(true);
                break;
            }
        }
    }

    private void Rot()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveDir = new Vector3(moveDir.x, moveDir.y, moveDir.z - rotatePower * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir = new Vector3(moveDir.x, moveDir.y, moveDir.z + rotatePower * Time.deltaTime);
        }
        if (moveDir.z >= 360 || moveDir.z <= -360)
        {
            moveDir.z = 0;
        }
        float rad = Mathf.Deg2Rad * (moveDir.z + 90);
        shootDir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;
    }
    private void SpShoot()
    {
        aniL.Shoot();
        aniR.Shoot();
    }
    #region 프로퍼티
    public Transform FireSpot
    {
        get { return fireSpot; }
        set { fireSpot = value; }
    }
    public Vector2 ShootDir
    {
        get { return shootDir; }
    }
    public Vector3 MoveDir
    {
        get { return moveDir; }
    }
    #endregion
}
