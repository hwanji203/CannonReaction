using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private float endX = -18;
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] float offset = 0.1f;

    private void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x <= endX)
        {
            transform.position = new Vector3(-endX - offset, transform.position.y, 0);
        }
    }
}
