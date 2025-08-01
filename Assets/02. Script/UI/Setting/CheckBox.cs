using UnityEngine;
using UnityEngine.UI;

public class CheckBox : MonoBehaviour
{
    [SerializeField] private CannonRotate[] rot;

    private Image image;
    private Color originalColor;
    private bool isChecked = false;

    private void Awake()
    {
        image = transform.GetChild(1).GetComponent<Image>();
        originalColor = image.color;
        SetAlpha(0);  // 초기 상태: 체크 해제 (투명)
    }

    public void Check()
    {
        isChecked = !isChecked;  // 상태 토글

        SetAlpha(isChecked ? originalColor.a : 0f);

        foreach (CannonRotate rotation in rot)
        {
            rotation.RotatePower *= -1;
        }
    }

    private void SetAlpha(float alpha)
    {
        Color newColor = image.color;
        newColor.a = alpha;
        image.color = newColor;
    }
}
