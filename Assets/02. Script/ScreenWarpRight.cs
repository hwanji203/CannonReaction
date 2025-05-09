using System;
using System.Collections;
using UnityEngine;

public class ScreenWarpRight : MonoBehaviour
{
    private EndManager endManager;
    private CannonDir cannonDir;
    [SerializeField] private float real = 0.5f;
    [SerializeField] private GameObject left;


    private void Awake()
    {
        endManager = GameObject.FindAnyObjectByType<EndManager>();
        cannonDir = GameObject.FindAnyObjectByType<CannonDir>();
    }
    private void Update()
    {
        Warp();
        transform.rotation = Quaternion.Euler(cannonDir.MoveDir);
    }
    private void Warp()
    {
        if (transform.position.x + real * 2< endManager.LeftDownEnd.x)
        {
            transform.position = left.gameObject.transform.position;
        }
        if (transform.position.x + real> endManager.RightUpEnd.x)
        {
            transform.position = new Vector3(endManager.LeftDownEnd.x - real, transform.position.y, 0);
        }
    }
}
