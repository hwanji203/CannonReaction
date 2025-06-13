using UnityEngine;

public class ExpMove : MonoBehaviour
{
    [SerializeField] private float drag = 1f;
    [SerializeField] private float addForcePower = 10f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        
    }
}
