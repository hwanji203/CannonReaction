using System;
using System.Collections;
using UnityEngine;

public class ScreenWarpLeft : MonoBehaviour
{
    [SerializeField] private float real = 0.5f;
    [SerializeField] private GameObject right;
    private CannonDir cannonDir;
    private EndManager endManager;

    private void Awake()
    {
        cannonDir = GameObject.FindAnyObjectByType<CannonDir>();
        endManager = GameObject.FindAnyObjectByType<EndManager>();
    }
    private void Update()
    {
        Warp();
        transform.rotation = Quaternion.Euler(cannonDir.MoveDir);
    }
    private void Warp()
    {
        if (transform.position.x - real < endManager.LeftDownEnd.x)
        {
            transform.position = new Vector3(endManager.RightUpEnd.x +real, transform.position.y, 0);
        }
        if (transform.position.x - real * 2 > endManager.RightUpEnd.x)
        {
            transform.position = right.gameObject.transform.position ;
        }
    }
}
