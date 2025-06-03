using System;
using System.Collections;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private float real;
    private EndManager endManager;

    private void Awake()
    {
        real = GetComponent<CircleCollider2D>().radius;
        endManager = GameObject.FindAnyObjectByType<EndManager>();
    }
    private void Update()
    {
        Del();
    }
    private void Del()
    {
        if (transform.position.x + real < endManager.LeftEnd || transform.position.y + real < endManager.LeftEnd ||
            transform.position.x - real > endManager.RightEnd || transform.position.y - real > endManager.RightEnd)
        {
            gameObject.SetActive(false);
        }
    }
}
