using UnityEngine;

public class ZombieClipEvent : SlimeClipEvent
{
    private ZombieRevive zombieRivive;
    private bool isFirst = true;

    protected override void Awake()
    {
        base.Awake();
        zombieRivive = GetComponent<ZombieRevive>();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        isFirst = true;
    }
    public override void CDeadEnd()
    {
        if (!isFirst)
        {
            base.CDeadEnd();
        }
        else
        {
            StartCoroutine(zombieRivive.Revive());
            isFirst = false;
        }
    }
}
