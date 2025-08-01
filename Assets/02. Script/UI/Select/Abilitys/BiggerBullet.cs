using UnityEngine;

public class BiggerBullet : BrickAbility
{
    GameObject cannons;
    private void Awake()
    {
        MaxCount = int.MaxValue;
        cannons = GameObject.Find("Cannons");
    }
    public override void Ability()
    {
        for (int i = 0; i < 3; i++)
        {
            cannons.transform.GetChild(i).GetComponent<CannonShoot>().Bigger += 
                (1 - cannons.transform.GetChild(i).GetComponent<CannonShoot>().Bigger) / 3;
        }
    }
}
