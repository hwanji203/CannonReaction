using System;
using UnityEngine;

public class ExpGauge : MonoBehaviour
{
    [SerializeField] private int levelUpExp;
    [SerializeField] private int nextLevelPlus;
    [SerializeField] private int nowExp = 0;

    private int levelUpCount = 1;

    public event Action LevelUpEvent;

    [SerializeField] private RectTransform collectUI;

    [SerializeField] private AudioClip clip;

    public double MaxValue { get; set; } = 10;
    private void Start()
    {
        ExpUpM();
    }
    public void ExpUp()
    {
        nowExp++;
        AudioManager.Instance.PlaySFX(clip, 1);
        ExpUpM();
    }

    private void ExpUpM()
    {
        while ((float)nowExp / levelUpExp >= 1)
        {
            LevelUp();
        }
        ChangeScale();
    }

    private void ChangeScale()
    {
        float percent = Mathf.Clamp01(((float)nowExp) / (levelUpExp - 1)); 
        float value = Mathf.Lerp(0f, (float)MaxValue, percent); 
        collectUI.localScale = new Vector3(value, value, 1);
    }

    private void LevelUp()
    {
        nowExp = 0;
        levelUpExp += nextLevelPlus * levelUpCount;
        levelUpCount++;
        LevelUpEvent?.Invoke();
    }
}
