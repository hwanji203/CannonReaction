using UnityEngine;

public class LiveZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            if (!bullet.SettingClear)
            {
                bullet.SettingClear = true;
                bullet.gameObject.SetActive(false);
            }
            else
            {
                bullet.Ready = true;
                bullet.InZone = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            bullet.gameObject.SetActive(false);
        }
    }
}
