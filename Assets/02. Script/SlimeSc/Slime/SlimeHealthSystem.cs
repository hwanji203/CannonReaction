using System;
using UnityEngine;
using UnityEngine.Rendering;

public class SlimeHealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    private int hp;

    private SlimeMovement slimeMove;

    private void Awake()
    {
        hp = maxHealth;
        slimeMove = GetComponent<SlimeMovement>();
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
}