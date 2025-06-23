 using UnityEngine;

public class LiveZone : MonoBehaviour
{
    public bool canWork = true;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (canWork && collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            bullet.gameObject.SetActive(false);
        }
    }
}
