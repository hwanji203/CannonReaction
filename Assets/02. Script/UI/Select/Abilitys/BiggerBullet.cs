using UnityEngine;

public class BiggerBullet : BrickAbility
{
    private CannonShoot cannon;
    private void Awake()
    {
        MaxCount = int.MaxValue;

        cannon = FindAnyObjectByType<CannonShoot>();
    }
    public override void Ability()
    {
        cannon.Bigger += (1 - cannon.Bigger) / 3;
    }
}
