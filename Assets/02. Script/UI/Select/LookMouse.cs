using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;
using UnityEngine.UI;

public class LookMouse : MonoBehaviour
{
    private RectTransform rectTransform;

    private Vector2 lookPos;

    [SerializeField] private RectTransform targetIcon;

    private Image image;

    public bool shooted = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        Color color = image.color;
        color.a = 0;
        image.color = color;

        GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }

    public void Fade()
    {
        Color color = image.color;
        color.a = 0;
        image.color = color;
    }

    public IEnumerator Enable()
    {
        shooted = false;

        Color color = image.color;
        color.a = 0;
        image.color = color;

        color = image.color;

        while (color.a < 1f)
        {
            color.a += 1.5f * Time.unscaledDeltaTime;
            image.color = color;
            yield return null;
        }

        // 마지막 값 보정
        color.a = 1f;
        image.color = color;

        shooted = false;
    }

    private void Update()
    {
        if (!shooted)
        {
            lookPos = (targetIcon.position - rectTransform.position).normalized;
            rectTransform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(Mathf.Rad2Deg * Mathf.Atan2(lookPos.y, lookPos.x) - 90, -60, 60));
        }
    }
}
