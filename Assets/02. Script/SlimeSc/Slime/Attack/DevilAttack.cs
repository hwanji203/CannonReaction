using UnityEngine;

public class DevilAttack : AttackToPlayer
{
    protected override void Awake()
    {
        base.Awake();

        cannon = new ByDevil[3];

        GameObject cannons = GameObject.Find("Cannons");

        for (int i = 0; i < cannon.Length; i++)
        {
            cannon[i] = cannons.transform.GetChild(i).GetComponent<ByDevil>();
        }
    }
}
