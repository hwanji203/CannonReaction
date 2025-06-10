using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    public Transform FireSpot { get; private set; }

    private GameObject[] bulletPool;
    private readonly int bulletPoolSize = 5;
    private Transform bulletPoolPa;

    private Player player;

    private void Awake()
    {
        FireSpot = GameObject.Find("FireSpotR").transform;
        bulletPoolPa = GameObject.Find("BulletPool").transform;
    }
    void Start()
    {
        player = GetComponent<Player>();
        player.shootEvnet += Fire;

        bulletPool = new GameObject[bulletPoolSize];
        for (int i = 0; i < bulletPoolSize; i++)
        {
            bulletPool[i] = Instantiate(bulletPrefab, bulletPoolPa);
            bulletPool[i].gameObject.SetActive(false);
        }

    }

    private void Fire()
    {
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullet = bulletPool[i];
            if (!bullet.activeSelf)
            {
                bullet.SetActive(true);
                bullet.transform.position = FireSpot.position;
                break;
            }
        }
    }
}
