using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonRotate : MonoBehaviour
{
    [SerializeField] private float rotatePower = 0.8f;
    private float moveX;

    private CannonEvent cannon;
    private void Awake()
    {
        cannon = GetComponent<CannonEvent>();
    }

    public void OnMove(InputValue value)
    {
        moveX = value.Get<Vector2>().x;
    }

    private void Update()
    {
        if (!cannon.IsShooting)  
        {
            transform.Rotate(0, 0, moveX * rotatePower);
        }
    }
}