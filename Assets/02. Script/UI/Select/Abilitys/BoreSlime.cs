using UnityEngine;

public class BoreSlime : BrickAbility
{
    private void Awake()
    {
        MaxCount = 1;
    }

    public override void Ability()
    {
        CountPlus();
        GameObject cannons = GameObject.Find("Cannons");
        for (int i = 0; i < 3; i++)
        {
            cannons.transform.GetChild(i).GetComponent<CannonShoot>().EnforceBullet();
        }
    }
}
