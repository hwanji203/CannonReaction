using UnityEngine;

public class CastleHit : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<SlimeAnimation>(out SlimeAnimation slime))
        {
            slime.Attack();
        }
    }
}
