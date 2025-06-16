using UnityEngine;

public class BasicAttack : AttackToPlayer
{
    protected override void Awake()
    {
        base.Awake();

        cannon = new ByBasic[3];

        cannon[0] = GameObject.Find("Cannon").GetComponent<ByBasic>();
        cannon[1] = GameObject.Find("CannonR").GetComponent<ByBasic>();
        cannon[2] = GameObject.Find("CannonL").GetComponent<ByBasic>();
    }
}
