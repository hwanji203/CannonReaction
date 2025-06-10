using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonRotate : MonoBehaviour
{
    [SerializeField] private float rotatePower = 0.8f;
    private float moveX;

    private Player player;
    private void Start()
    {
        player = GetComponent<Player>();
    }

    public void OnMove(InputValue value)
    {
        moveX = value.Get<Vector2>().x;
    }

    private void Update()
    {
        if (player.ShootCoroutine == null)
        {
            transform.Rotate(0, 0, moveX * rotatePower);
        }
    }
}