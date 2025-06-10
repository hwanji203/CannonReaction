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
    }

    private void Start()
    {
        endManager = EndManager.Instance;
    }
    private void Update()
    {
        Del();
    }
    private void Del()
    {
        Vector2 pos = transform.position;
        float left = endManager.LeftEnd;
        float right = endManager.RightEnd;

        if (pos.x + real < left || pos.y + real < left || pos.x - real > right || pos.y - real > right)
        {
            gameObject.SetActive(false);
        }
    }
}
