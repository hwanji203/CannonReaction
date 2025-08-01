using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonRotate : MonoBehaviour
{
    public float RotatePower { get; set; } = 0.8f;
    private float moveX;

    public void OnMove(InputValue value)
    {
        moveX = value.Get<Vector2>().x;
    }

    private void Update()
    {
        transform.Rotate(0, 0, moveX * RotatePower * 50 * Time.deltaTime);
    }
}