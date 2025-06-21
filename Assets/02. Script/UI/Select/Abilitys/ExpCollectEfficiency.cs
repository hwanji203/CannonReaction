using UnityEngine;

public class ExpCollectEfficiency : BrickAbility
{
    ExpGauge gauge;
    [SerializeField] float upValue = 1.25f;

    GameObject[] upObject;
    private void Awake()
    {
        MaxCount = 2;

        upObject = new GameObject[3];
        upObject[0] = GameObject.Find("ExpCollector");
        upObject[1] = upObject[0].transform.GetChild(0).gameObject;
        upObject[2] = GameObject.Find("ExpCollecterUI");

        gauge = FindAnyObjectByType<ExpGauge>();
    }
    public override void Ability()
    {
        CountPlus();

        gauge.MaxValue *= upValue;
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
