using System.Collections;
using UnityEngine;

public class ZombieRevive : MonoBehaviour
{
    [SerializeField] private float waitTime;
    private SlimeAnimation slimeAni;
    public bool IsReviving { get; private set; } = false;

    private void Awake()
    {
        slimeAni = GetComponent<SlimeAnimation>();
    }
    public IEnumerator Revive()
    {
        IsReviving = true;
        yield return new WaitForSeconds(waitTime);
        slimeAni.ReviveAnimation();
        IsReviving = false;
    }
}
