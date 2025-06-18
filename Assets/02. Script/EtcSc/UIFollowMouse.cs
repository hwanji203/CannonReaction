using UnityEngine;

public class UIFollowMouse : MonoBehaviour
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    private void Update()
    {
        Vector2 mousePos;
        RectTransform canvasRect = canvas.transform as RectTransform;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect,
            Input.mousePosition,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera,
            out mousePos
        );
        Vector2 halfCanvas = canvasRect.rect.size / 2;
        Vector2 halfSize = rectTransform.rect.size / 2;

        float limitX = halfCanvas.x;
        float limitY = halfCanvas.y;

        //  제한 적용 (Clamp)
        mousePos.x = Mathf.Clamp(mousePos.x, -limitX, limitX);
        mousePos.y = Mathf.Clamp(mousePos.y, -limitY, limitY);

        // 위치 적용
        rectTransform.anchoredPosition = mousePos;
    }

}
