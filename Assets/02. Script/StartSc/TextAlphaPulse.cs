using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TextAlphaPulse : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI targetText;
    [SerializeField] private float pulseSpeed = 1f;      // 알파 변화 속도
    [SerializeField] private float minAlpha = 0.2f;      // 최소 알파값
    [SerializeField] private float maxAlpha = 1f;        // 최대 알파값

    private Color originalColor;

    private void Awake()
    {
        if (targetText == null)
            targetText = GetComponent<TextMeshProUGUI>();

        originalColor = targetText.color;
    }

    private void Update()
    {
        float alpha = Mathf.Lerp(minAlpha, maxAlpha, (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f);

        Color newColor = originalColor;
        newColor.a = alpha;
        targetText.color = newColor;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentIndex + 1);
        }
    }
}
