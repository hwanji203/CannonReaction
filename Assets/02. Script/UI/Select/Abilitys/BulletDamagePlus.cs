using UnityEngine;

public class BulletDamagePlus : BrickAbility
{
    private CannonShoot shoot;
    private void Awake()
    {
        MaxCount = int.MaxValue;

        shoot = FindAnyObjectByType<CannonShoot>();
    }
    public override void Ability()
    {
        shoot.BulletDamage++;
    }
}
