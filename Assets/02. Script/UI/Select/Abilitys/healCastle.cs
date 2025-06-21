using UnityEngine;

public class healCastle : BrickAbility
{
    [SerializeField] private int healValue = 5;

    private CastleHealthSystem castle;

    private void Awake()
    {
        MaxCount = int.MaxValue;
        castle = FindAnyObjectByType<CastleHealthSystem>();
    }
    public override void Ability()
    {
        castle.GetHeal(healValue);
    }
}
