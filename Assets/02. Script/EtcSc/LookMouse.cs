using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;

public class LookMouse : MonoBehaviour
{
    private RectTransform rectTransform;

    private Vector2 lookPos;

    private ExpGauge expGauge;
    [SerializeField] private RectTransform targetIcon;

    private void Awake()
    {
        expGauge = FindAnyObjectByType<ExpGauge>();
        rectTransform = GetComponent<RectTransform>();
    }
    private void Start()
    {
        expGauge.LevelUpEvent += Enable;
        gameObject.SetActive(false);
    }

    private void Enable()
    {
        gameObject.SetActive(true);
    }
    private void Update()
    {
        lookPos = (targetIcon.position - rectTransform.position).normalized;
        rectTransform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(lookPos.y, lookPos.x) - 90);
    }
}
