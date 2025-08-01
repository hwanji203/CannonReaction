using UnityEngine;

public class Ilac : AttackToPlayer
{
    protected override void Awake()
    {
        base.Awake();

        cannon = new ByIlac[3];

        GameObject cannons = GameObject.Find("Cannons");

        for (int i = 0; i < cannon.Length; i++)
        {
            cannon[i] = cannons.transform.GetChild(i).GetComponent<ByIlac>();
        }
    }
}
