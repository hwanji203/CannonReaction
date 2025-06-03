using System;
using System.Collections;
using UnityEngine;

public class ScreenWarpLeft : MonoBehaviour
{
    [SerializeField] private float real = 0.5f;
    [SerializeField] private GameObject right;
    private EndManager endManager;

    private void Awake()
    {
        endManager = GameObject.FindAnyObjectByType<EndManager>();
        gameObject.SetActive(false);
    }
    private void Update()
    {
        Warp();
    }
    private void Warp()
    {
        float left = transform.position.x - real;
        if (left < endManager.LeftEnd)
        {
            transform.position = new Vector3(endManager.RightEnd + real, transform.position.y, 0);
            gameObject.SetActive(false);
        }
        float leftAdd = transform.position.x - real * 2;
        if (leftAdd > endManager.RightEnd)
        {
            transform.position = right.gameObject.transform.position;
            gameObject.SetActive(false);
        }
    }
}
