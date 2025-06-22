using UnityEngine;

public class ExpCollectEfficiency : BrickAbility
{
    ExpGauge gauge;
    [SerializeField] float upValue = 1.25f;

    GameObject[] upObject;
    private void Awake()
    {
        MaxCount = 2;

        upObject = new GameObject[2];
        upObject[0] = GameObject.Find("ExpCollector");
        upObject[1] = GameObject.Find("ExpCollecterUI");

        gauge = FindAnyObjectByType<ExpGauge>();
    }
    public override void Ability()
    {
        CountPlus();

        UpScale(upValue);
    }

    private void UpScale(float value)
    {
        foreach (GameObject ga in upObject)
        {
            ga.transform.localScale *= value;
        }
    }
}
