using UnityEngine;

public abstract class BrickAbility : MonoBehaviour
{
    public int Count { get; private set; } = 0;
    public int MaxCount { get; set; }

    public void CountPlus()
    {
        Count++;
    }

    public abstract void Ability();
}
