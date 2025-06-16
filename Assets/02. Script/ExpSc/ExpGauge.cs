using System;
using UnityEngine;

public class ExpGauge : MonoBehaviour
{
    [SerializeField] private int levelUpExp;
    [SerializeField] private int nextLevelPlus;
    [SerializeField] private int nowExp = 0;

    private int levelUpCount = 0;

    public event Action LevelUpEvent;

    private void Awake()
    {
        ChangeScale();
    }
    public void ExpUp()
    {
        nowExp++;
        if ((float)nowExp / levelUpExp > 1)
        {
            LevelUp();
        }
        ChangeScale();
    }

    private void ChangeScale()
    {
        float percent = Mathf.Clamp01((float)nowExp / (float)levelUpExp); // 0~1로 제한
        float value = Mathf.Lerp(0f, 10f, percent); // 크기 0.5배 → 1배
        transform.localScale = new Vector3(value, value, 1);
    }

    private void LevelUp()
    {
        nowExp = 0;
        levelUpExp += nextLevelPlus * levelUpCount;
        levelUpCount++;
        LevelUpEvent?.Invoke();
    }
}
