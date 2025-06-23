using UnityEngine;

public class IceAttack : AttackToPlayer
{
    protected override void Awake()
    {
        base.Awake();

        cannon = new ByIce[3];

        GameObject cannons = GameObject.Find("Cannons");

        for (int i = 0; i < cannon.Length; i++)
        {
            cannon[i] = cannons.transform.GetChild(i).GetComponent<ByIce>();
        }
    }
}
