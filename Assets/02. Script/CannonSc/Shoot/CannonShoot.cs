using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    [SerializeField] private GameObject[] bulletPrefabs;
    [SerializeField] private Transform fireSpot;

    [SerializeField] private Transform bulletPoolPa;
    private readonly int bulletPoolSize = 5;

    private CannonEvent player;

    private string bulletKey;

    private Dictionary<string, GameObject[]> bulletPools;

    private Bullet bulletSc;
    private void Awake()
    {
        player = GetComponent<CannonEvent>();

        bulletPools = new Dictionary<string, GameObject[]>();

        BulletPoolMake();

        bulletKey = bulletPrefabs[0].name;
    }

    private void BulletPoolMake()
    {
        for (int i = 0; i < bulletPrefabs.Length; i++)
        {
            GameObject[] bullets = new GameObject[bulletPoolSize];
            for (int j = 0; j < bulletPoolSize; j++)
            {
                bullets[j] = Instantiate(bulletPrefabs[i], bulletPoolPa);
            }
            bulletPools.Add(bulletPrefabs[i].name, bullets);
        }
    }

    void Start()
    {

        player.shootEvnet += Fire;

    }

    private void Fire()
    {
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullet = bulletPools[bulletKey][i];
            if (!bullet.activeSelf)
            {
                bulletSc = bullet.GetComponent<Bullet>();
                bullet.transform.position = fireSpot.position;
                bulletSc.zValue = transform.eulerAngles.z - 90;
                bullet.SetActive(true);
                break;
            }
        }
    }
}
