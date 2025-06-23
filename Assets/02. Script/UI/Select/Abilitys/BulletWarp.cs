using UnityEngine;

public class BulletWarp : BrickAbility
{
    private GameObject coll;
    [SerializeField] CannonShoot shoot;
    private void Awake()
    {
        MaxCount = 1;

        coll = GameObject.Find("BulletLiveZone");
    }
    public override void Ability()
    {
        CountPlus();
        GameObject cannons = GameObject.Find("Cannons");
        for (int i = 0; i < 3; i++)
        {
            cannons.transform.GetChild(i).GetComponent<CannonShoot>().CanWarp = true;
        }
    }
}
