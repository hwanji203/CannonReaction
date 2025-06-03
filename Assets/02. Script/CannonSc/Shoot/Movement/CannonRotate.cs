using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonRotate : MonoBehaviour
{
    [SerializeField] private float rotatePower = 0.8f;
    private Vector3 moveDir;

    private Player player;
    private void Start()
    {
        player = GetComponent<Player>();
        moveDir = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if (player.ShootCoroutine == null)
        {
            Rot();
        }
    }
    private void Rot()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,0, -1 * rotatePower);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, 1 * rotatePower);
        }
    }
}