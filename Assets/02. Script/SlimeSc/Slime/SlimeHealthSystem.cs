using System;
using UnityEngine;
using UnityEngine.Rendering;

public class SlimeHealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    private int hp;

    private SlimeAnimation slimeMove;

    private void Awake()
    {
        slimeMove = GetComponent<SlimeAnimation>();
    }
    public void TakeDamage(int damage)
    {
        if (hp <= damage)
        {
            slimeMove.Dead();
        }
        else
        {
            hp -= damage;
            slimeMove.Hit();
        }
    }

    public void ResetHP()
    {
        hp = maxHealth;
    }
}