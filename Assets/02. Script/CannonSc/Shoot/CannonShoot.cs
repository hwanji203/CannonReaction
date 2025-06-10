using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    [SerializeField] private GameObject[] bulletPrefabs;
    [SerializeField] private Transform fireSpot;

    [SerializeField] private Transform bulletPoolPa;
    private readonly int bulletPoolSize = 5;

    private Player player;

    private string bulletType = "BasicBullet";

    Dictionary<string, GameObject[]> bulletPools;
    void Start()
    {

        player = GetComponent<Player>();
        player.shootEvnet += Fire;

        bulletPools = new Dictionary<string, GameObject[]>();

        for (int i = 0; i < bulletPrefabs.Length; i++)
        {
            GameObject[] bullets = new GameObject[bulletPoolSize];
            for (int j = 0; j < bulletPoolSize; j++)
            {
                bullets[j] = Instantiate(bulletPrefabs[i]);
                bullets[j].GetComponent<Bullet>().SettingClear = true;
                bullets[j].SetActive(false);
            }
            bulletPools.Add(bulletPrefabs[i].name, bullets);
        }
    }

    private void Fire()
    {
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullet = bulletPools[bulletType][i];
            if (!bullet.activeSelf)
            {
                bullet.transform.position = fireSpot.position;
                Bullet bulletSc = bullet.GetComponent<Bullet>();
                bulletSc.zValue = transform.eulerAngles.z - 90;
                bullet.SetActive(true);
                break;
            }
        }
    }
}
