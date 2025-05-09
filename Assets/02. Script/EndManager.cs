using UnityEngine;

public class EndManager : MonoBehaviour
{
    private Vector2 leftDownEnd;
    private Vector2 rightUpEnd;

    private void Awake()
    {
        leftDownEnd = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        rightUpEnd = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void Update()
    {
        leftDownEnd = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        rightUpEnd = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    public Vector2 LeftDownEnd
    {
        get { return leftDownEnd; }
    }
    public Vector2 RightUpEnd
    {
        get { return rightUpEnd; }
    }
}
