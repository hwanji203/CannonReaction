using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChooseOne : MonoBehaviour
{
    [SerializeField] private RectTransform breakBall;
    [SerializeField] private float offset = 10f;

    [SerializeField] private Animator animator;

    private Canvas canvas;

    [SerializeField] private float waitTime = 0.75f;

    [SerializeField] Animator[] brickAnimator;
    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;

    }

    public void Choose()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            return;
        }
        RectTransform button = EventSystem.current.currentSelectedGameObject.GetComponent<RectTransform>();
        if (button == null)
        {
            return;
        };

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

        // 핵심 수정: 위치 먼저 잡고 SetSibling
        breakBall.SetParent(button, false);
        breakBall.anchoredPosition = localMousePos;
        breakBall.SetAsLastSibling(); // 가장 위에 보이게


        StartCoroutine(WaitBullet(EventSystem.current.currentSelectedGameObject.GetComponent<Animator>()));
        foreach (Animator button1 in brickAnimator)
        {
            button1.gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public IEnumerator WaitBullet(Animator button)
    {
        animator.SetTrigger("select");
        yield return new WaitForSecondsRealtime(waitTime);
        breakBall.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.75f);
        foreach (Animator ani in brickAnimator)
        {
            if (ani != button)
            {
                ani.SetTrigger("notSelected");
            }
            else
            {
                button.SetTrigger("selected");
            }
        }
    }
}
