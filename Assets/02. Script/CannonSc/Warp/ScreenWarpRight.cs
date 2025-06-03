using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class ScreenWarpRight : MonoBehaviour
{
    private EndManager endManager;
    [SerializeField] private float real = 0.5f;
    [SerializeField] private GameObject left;

    private void Awake()
    {
        endManager = GameObject.FindAnyObjectByType<EndManager>();
        left.gameObject.SetActive(false);
    }
    private void Update()
    {
        Warp();
    }
    private void Warp()
    {
        RightWarp();
        LeftWarp();
    }

    private void LeftWarp()
    {
        float lefthit = transform.position.x - real;
        if (lefthit < endManager.LeftEnd)
        {
            left.transform.position = new Vector3(endManager.RightEnd + real, left.transform.position.y, 0);
            left.SetActive(false);
        }
        float lefthitAdd = transform.position.x - real * 2;
        if (lefthitAdd > endManager.RightEnd)
        {
            left.transform.position = transform.position;
            left.SetActive(false);
        }
    }

    private void RightWarp()
    {
        float rightAdd = transform.position.x + real * 2;
        if (rightAdd < endManager.LeftEnd)
        {
            left.gameObject.SetActive(true);
            transform.position = left.gameObject.transform.position;
        }
        float right = transform.position.x + real;
        if (right > endManager.RightEnd)
        {
            left.gameObject.SetActive(true);
            transform.position = new Vector3(endManager.LeftEnd - real, transform.position.y, 0);
        }
    }
}
