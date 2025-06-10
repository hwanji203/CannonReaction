using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform fireSpot;

    [SerializeField] private GameObject[] bulletPool;
    [SerializeField] private Transform bulletPoolPa;
    private readonly int bulletPoolSize = 5;

    private Player player;
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
                bullet.transform.position = fireSpot.position;
                bullet.GetComponent<Bullet>().zValue = transform.eulerAngles.z -90;
                bullet.SetActive(true);
                break;
            }
        }
    }
}
