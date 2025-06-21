using UnityEngine;
using System;


public class SlimeHit : MonoBehaviour
{
    protected SlimeHealthSystem healthSystem;

    protected virtual void Awake()
    {
        healthSystem = GetComponent<SlimeHealthSystem>();
    }
}
