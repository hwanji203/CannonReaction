using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChooseOne : MonoBehaviour
{
    [SerializeField] private RectTransform breakBall;
    [SerializeField] private float offset = 10f;

    [SerializeField] private Animator animator;

    private Canvas canvas;

    [SerializeField] private float waitTime = 0.75f;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    public void Choose()
    {
        if (EventSystem.current.currentSelectedGameObject == null) return;

        RectTransform button = EventSystem.current.currentSelectedGameObject.GetComponent<RectTransform>();
        if (button == null) return;

        Vector2 localMousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            button,
            Input.mousePosition,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera,
            out localMousePos
        );

        float limitX = button.rect.width / 2 - offset;
        float limitY = button.rect.height / 2 - offset;

        localMousePos.x = Mathf.Clamp(localMousePos.x, -limitX, limitX);
        localMousePos.y = Mathf.Clamp(localMousePos.y, -limitY, limitY);

        breakBall.anchoredPosition = button.anchoredPosition + localMousePos;
        breakBall.SetParent(button);

        StartCoroutine(WaitBullet());
    }

    public IEnumerator WaitBullet()
    {
        animator.SetTrigger("select");
        yield return new WaitForSecondsRealtime(waitTime);
        breakBall.gameObject.SetActive(true);
    }
}
