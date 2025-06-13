using UnityEngine;

public class CastleHit : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<SlimeMovement>(out SlimeMovement slime))
        {
            slime.SlimeAttack();
        }
    }
}
