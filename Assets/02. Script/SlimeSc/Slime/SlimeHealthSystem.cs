using System;
using UnityEngine;

public class SlimeHealthSystem : MonoBehaviour
{
    [SerializeField] private int startHp = 2;
    [SerializeField] private int endHp = 8;
    [field: SerializeField] public int Hp { get; private set; }

    private int maxHealth;

    private SlimeAnimation slimeMove;
    private SlimeSpawnDifficulty diff;

    private void Awake()
    {
        slimeMove = GetComponent<SlimeAnimation>();
        diff = FindAnyObjectByType<SlimeSpawnDifficulty>();
    }

    private void Start()
    {
        // 초기 체력 설정
        maxHealth = startHp;
        Hp = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        if (Hp <= damage)
        {
            slimeMove.Dead();
        }
        else
        {
            Hp -= damage;
            slimeMove.Hit();
        }
    }

    public void ResetHP()
    {
        float t = Mathf.Clamp01(Time.time / diff.Playtime);
        maxHealth = Mathf.RoundToInt(Mathf.Lerp(startHp, endHp, t));
        Hp = maxHealth;
    }
}
