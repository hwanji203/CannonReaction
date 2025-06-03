using UnityEngine;

public class EndManager : MonoBehaviour
{
    public float LeftEnd { get; private set; }
    public float RightEnd { get; private set; }

    private void Awake()
    {
        LeftEnd = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        RightEnd = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x;
    }   
}
