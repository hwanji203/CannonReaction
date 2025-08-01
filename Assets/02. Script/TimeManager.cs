using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float NowTime { get; private set; }
    private float startTime;

    public static TimeManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        startTime = Time.time;
    }

    public float GetTime()
    {
        NowTime = Time.time - startTime;
        return NowTime;
    }
}
