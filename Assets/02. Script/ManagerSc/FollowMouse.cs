using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Camera mainCam;
    private float minX, maxX, minY, maxY;
    private SpriteRenderer spriteRen;

    private void Awake()
    {
        mainCam = Camera.main;
        spriteRen = GetComponent<SpriteRenderer>();
        UpdateBounds();
    }

    private void UpdateBounds()
    {
        Vector2 min = mainCam.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = mainCam.ViewportToWorldPoint(new Vector2(1, 1));

        minX = min.x;
        maxX = max.x;
        minY = min.y;
        maxY = max.y;
    }

    private void Update()
    {
        FollowMouseM();
        UpdateBounds();
    }

    private void FollowMouseM()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = mainCam.ScreenToWorldPoint(mousePos);
        worldPos.z = 0f;

        worldPos.x = Mathf.Clamp(worldPos.x, minX, maxX);
        worldPos.y = Mathf.Clamp(worldPos.y, minY, maxY);

        transform.position = worldPos;
    }
}
