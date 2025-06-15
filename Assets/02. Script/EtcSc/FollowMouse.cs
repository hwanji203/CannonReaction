using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Camera mainCam;
    private float minX, maxX, minY, maxY;

    private void Awake()
    {
        mainCam = Camera.main;

        // 카메라의 화면 경계 계산
        GetEnd();
    }

    private void GetEnd()
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
        GetEnd();

        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = mainCam.ScreenToWorldPoint(mousePos);
        worldPos.z = 0f;

        // 화면 안으로 제한
        worldPos.x = Mathf.Clamp(worldPos.x, minX, maxX);
        worldPos.y = Mathf.Clamp(worldPos.y, minY, maxY);

        transform.position = worldPos;
    }

}
