using UnityEngine;
using TMPro;

public class TextMovement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI targetText;

    [Header("크기 진동")]
    [SerializeField] private float scaleSpeed = 1.5f;
    [SerializeField] private float scaleAmount = 0.1f;

    [Header("Z축 회전 효과")]
    [SerializeField] private float tiltSpeed = 2.0f;
    [SerializeField] private float tiltAmount = 10f;

    private Vector3 originalScale;
    private Quaternion originalRotation;

    private void Awake()
    {
        if (targetText == null)
            targetText = GetComponent<TextMeshProUGUI>();

        originalScale = targetText.transform.localScale;
        originalRotation = targetText.transform.rotation;
    }

    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(PulseAndTilt());
    }

    private System.Collections.IEnumerator PulseAndTilt()
    {
        float scaleTimer = 0f;
        float tiltTimer = 0f;

        while (true)
        {
            // 개별 시간 증가
            scaleTimer += Time.deltaTime * scaleSpeed;
            tiltTimer += Time.deltaTime * tiltSpeed;

            // 크기 진동
            float scaleFactor = 1 + Mathf.Sin(scaleTimer) * scaleAmount;
            targetText.transform.localScale = originalScale * scaleFactor;

            // Z축 회전 진동
            float zRotation = Mathf.Sin(tiltTimer) * tiltAmount;
            targetText.transform.rotation = originalRotation * Quaternion.Euler(0, 0, zRotation);

            yield return null;
        }
    }

    private void OnDisable()
    {
        if (targetText != null)
        {
            targetText.transform.localScale = originalScale;
            targetText.transform.rotation = originalRotation;
        }
    }
}
