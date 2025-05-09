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
        if (transform.position.x + real < endManager.LeftDownEnd.x || transform.position.y + real < endManager.LeftDownEnd.y ||
            transform.position.x - real > endManager.RightUpEnd.x || transform.position.y - real > endManager.RightUpEnd.y)
        {
            gameObject.SetActive(false);
        }
    }
}
