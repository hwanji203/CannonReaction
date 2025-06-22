using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private BrickAbility[] bricks;
    private readonly int startSelectHash = Animator.StringToHash("startSelect");

    private Animator[] bricksAni;

    private ChooseOne choose;
    private void Awake()
    {
        choose = GetComponent<ChooseOne>();
    }
    private void Start()
    {
        foreach (BrickAbility brick in bricks)
        {
            brick.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
            brick.gameObject.SetActive(false);
        }
    }
    public void StartSelect()
    {
        int value1;
        do
        {
            value1 = Random.Range(0, bricks.Length);
        } while (bricks[value1].Count >= bricks[value1].MaxCount);
        int value2;
        do
        {
            value2 = Random.Range(0, bricks.Length);
        } while (value2 == value1 || bricks[value2].Count >= bricks[value2].MaxCount);
        int value3;
        do
        {
            value3 = Random.Range(0, bricks.Length);
        } while (value3 == value1 || value2 == value3 || bricks[value3].Count >= bricks[value3].MaxCount);

        bricks[value1].GetComponent<SelectAnimationEvent>().IsThat = true;
        bricks[value2].GetComponent<SelectAnimationEvent>().IsThat = false;
        bricks[value3].GetComponent<SelectAnimationEvent>().IsThat = false;


        UIMove(560, bricks[value2].GetComponent<RectTransform>());
        UIMove(-560, bricks[value3].GetComponent<RectTransform>());

        bricksAni = new Animator[3] { bricks[value1].GetComponent<Animator>(), bricks[value2].GetComponent<Animator>(), bricks[value3].GetComponent<Animator>() };

        choose.BrickAnimator = bricksAni;
        StartAnimation(bricksAni);
    }

    private void UIMove(int value, RectTransform tran)
    {
        Vector2 pos = tran.anchoredPosition;
        pos.x = value;
        tran.anchoredPosition = pos;
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
