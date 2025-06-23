 using UnityEngine;

public class LiveZone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            bullet.gameObject.SetActive(false);
        }
    }
}
