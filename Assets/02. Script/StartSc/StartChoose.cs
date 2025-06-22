using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartChoose : MonoBehaviour
{
    [SerializeField] protected RectTransform breakBall;
    [SerializeField] protected float offset = 10f;

    [SerializeField] protected Animator animator;

    protected Canvas canvas;

    [SerializeField] protected float waitTime = 0.75f;

    public Animator[] BrickAnimator { get; set; }

    protected LookMouse lookMouse;
    protected virtual void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;

        lookMouse = animator.gameObject.GetComponent<LookMouse>();
    }

    public virtual void Choose()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            return;
        }
        RectTransform button = EventSystem.current.currentSelectedGameObject.GetComponent<RectTransform>();
        if (button == null)
        {
            return;
        }
        ;

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
        foreach (Animator button1 in BrickAnimator)
        {
            button1.gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public virtual IEnumerator WaitBullet(Animator button)
    {
        animator.SetTrigger("select");
        lookMouse.shooted = true;
        yield return new WaitForSecondsRealtime(waitTime);
        breakBall.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.75f);
        foreach (Animator ani in BrickAnimator)
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
