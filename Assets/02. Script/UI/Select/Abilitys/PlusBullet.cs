using UnityEngine;

public class PlusBullet : BrickAbility
{
    private void Awake()
    {
        MaxCount = 2;
    }
    public override void Ability()
    {
        CountPlus();
        GameObject cannons = GameObject.Find("Cannons");
        for (int i = 0; i < 3; i++)
        {
            if (Count == 1)
            {
                cannons.transform.GetChild(i).GetComponent<CannonShoot>().ChangeFire(2);
            }
            else
            {
                cannons.transform.GetChild(i).GetComponent<CannonShoot>().ChangeFire(2);
            }
        }
    }
}
