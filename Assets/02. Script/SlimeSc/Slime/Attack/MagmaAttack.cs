using UnityEngine;

public class MagmaAttack : AttackToPlayer
{
    private void Awake()
    {
        cannon = new ByMagma[3];

        cannon[0] = GameObject.Find("Cannon").GetComponent<ByMagma>();
        cannon[1] = GameObject.Find("CannonR").GetComponent<ByMagma>();
        cannon[2] = GameObject.Find("CannonL").GetComponent<ByMagma>();
    }
}
