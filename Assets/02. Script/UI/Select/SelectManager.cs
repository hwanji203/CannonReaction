using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private Animator[] bricks;
    private readonly int startSelectHash = Animator.StringToHash("startSelect");

    private ExpGauge expGauge;
    private void Awake()
    {
        expGauge = FindAnyObjectByType<ExpGauge>();

        foreach (Animator brick in bricks)
        {
            brick.updateMode = AnimatorUpdateMode.UnscaledTime;
            brick.gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        expGauge.LevelUpEvent += StartSelect;
    }

    private void StartSelect()
    {
        int value1 = Random.Range(0, bricks.Length);

        int value2;
        do
        {
            value2 = Random.Range(0, bricks.Length);
        } while (value2 == value1);

        int value3;
        do
        {
            value3 = Random.Range(0, bricks.Length);
        } while (value3 == value1 || value3 == value2);



    }
    private void StartAnimation(Animator[] selected)
    {
        foreach (Animator brick in selected)
        {
            brick.gameObject.SetActive(true);
            brick.SetTrigger(startSelectHash);
        }
    }
}
