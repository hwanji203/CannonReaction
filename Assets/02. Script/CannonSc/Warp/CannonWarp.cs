using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class CannonWarp : MonoBehaviour
{
    private float end;
    private float rightend;
    private float leftend;
    [SerializeField] private float plus;
    private Vector2 startVector;

    private void Start()
    {
        end = EndManager.Instance.RightEnd;
        startVector = transform.position;
        rightend = startVector.x + plus + end;
        leftend = startVector.x - plus - end;
    }

    private void Update()
    {
        MainWarp();
    }

    private void MainWarp()
    {
        if (gameObject.transform.position.x > rightend)
        {
            Debug.Log("왼쪽으로 워프함");
            gameObject.transform.position =  new Vector3(leftend + 2 * plus, gameObject.transform.position.y, 0);
        }
        else if (gameObject.transform.position.x < leftend)
        {
            Debug.Log("오른쪽으로 워프함");
            gameObject.transform.position =  new Vector3(rightend - 2 * plus, gameObject.transform.position.y, 0);
        }
    }
}
