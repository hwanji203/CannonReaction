using UnityEngine;
using UnityEngine.EventSystems;
using TMPro; // TextMeshPro 사용 시

public class TextColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI targetText; // 버튼 안의 텍스트

    [SerializeField] private Color normalColor;
    [SerializeField] private Color hoverColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetText.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetText.color = normalColor;
    }
}

