using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform fireSpot;

    [SerializeField] private Transform bulletPoolPa;
    private readonly int bulletPoolSize = 20;

    private CannonEvent player;

    private GameObject[] bulletPool;

    private Bullet bulletSc;
    private bool boreSlime = false;
    public float Bigger { get; set; } = 0;
    public float KnockbackPower { get; set; } = 1f;
    public int BulletDamage { get; set; } = 1;
    public bool CanWarp { get; set; } = false;

    [SerializeField] BoxCollider2D moreArea;
    private void Awake()
    {
        player = GetComponent<CannonEvent>();

        bulletPool = new GameObject[bulletPoolSize];

        BulletPoolMake();
    }

    private void BulletPoolMake()
    {
        for (int j = 0; j < bulletPoolSize; j++)
        {
            bulletPool[j] = Instantiate(bulletPrefab, bulletPoolPa);
            bulletPool[j].SetActive(false);
        }
    }

    private void Start()
    {
        player.shootEvnet += Fire;
    }

    public void EnforceBullet()
    {
        boreSlime = true;
    }

    private void Fire()
    {
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullet = bulletPool[i];
            if (!bullet.activeSelf)
            {
                bulletSc = bullet.GetComponent<Bullet>();
                bullet.transform.position = fireSpot.position;
                bulletSc.zValue = transform.eulerAngles.z - 90;
                Ability();
                bullet.SetActive(true);
                break;
            }
        }
    }
    private void Fire(float angle)
    {
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullet = bulletPool[i];
            if (!bullet.activeSelf)
            {
                bulletSc = bullet.GetComponent<Bullet>();
                bullet.transform.position = fireSpot.position;
                bulletSc.zValue = transform.eulerAngles.z - 90 + angle;
                Ability();
                bullet.SetActive(true);
                break;
            }
        }
    }

    private void Ability()
    {
        bulletSc.KnockBackPower = KnockbackPower;
        bulletSc.BoreSlime = boreSlime;
        if (Random.Range(0f, 1f) <= Bigger)
        {
            bulletSc.Bigger = true;
        }
        else
        {
            bulletSc.Bigger = false;
        }
        if (CanWarp)
        {
            bulletSc.AllowedArea = moreArea;
        }
        bulletSc.BulletDamage = BulletDamage;
    }
    public void ChangeFire(int level)
    {
        if (level == 2)
        {
            player.shootEvnet -= Fire;
            player.shootEvnet += Fire2;
        }
        else if (level == 3)
        {
            player.shootEvnet -= Fire2;
            player.shootEvnet += Fire3;
        }
        else
        {
            Debug.Log("ChangeFIre ½ÇÆÐ");
        }
    }
    private void Fire2()
    {
        Fire(-20);
        Fire(20);
    }
    private void Fire3()
    {
        Fire(0);
        Fire(-30);
        Fire(30);
    }
}
