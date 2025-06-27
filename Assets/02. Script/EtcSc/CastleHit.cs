using UnityEngine;

public class CastleHit : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<SlimeAnimation>(out var slime))
        {
            Bounds myBounds = GetComponent<Collider2D>().bounds;
            Bounds slimeBounds = slime.GetComponent<Collider2D>().bounds;

            if (myBounds.Contains(slimeBounds.min) &&
                myBounds.Contains(slimeBounds.max) &&
                myBounds.Contains(new Vector2(slimeBounds.min.x, slimeBounds.max.y)) &&
                myBounds.Contains(new Vector2(slimeBounds.max.x, slimeBounds.min.y)))
            {
                slime.Attack();
            }
        }
    }
}
