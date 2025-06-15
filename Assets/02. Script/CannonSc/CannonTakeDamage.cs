using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonTakeDamage : MonoBehaviour
{

    private CannonEvent cannon;

    [SerializeField] private GameObject[] slimes;
    public Dictionary<BySlime, Action> slimeEffects;
    private void Awake()
    {
        cannon = GetComponent<CannonEvent>();

        slimeEffects = new Dictionary<BySlime, Action>();
    }

    private void Start()
    {
        cannon.TakeDamageEvent += TakeDamage;
    }
    private void TakeDamage(BySlime name)
    {
        slimeEffects[name]();
    }
}
