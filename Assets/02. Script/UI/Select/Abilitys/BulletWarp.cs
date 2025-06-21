using UnityEngine;

public class BulletWarp : BrickAbility
{
    private GameObject coll;
    private void Awake()
    {
        MaxCount = 1;

        coll = GameObject.Find("BulletLiveZone");
    }
    public override void Ability()
    {
        CountPlus();
        coll.SetActive(false);
    }
}
