using UnityEngine;
using UnityEngine.UIElements;

public class LRWarp : MonoBehaviour
{
    [SerializeField] private Transform real;

    [SerializeField] private bool isRight = false;
    private float end;

    private EndManager endM;
    private void Start()
    {
        endM = EndManager.Instance;
        if (isRight == true)
        {
            end = endM.RightEnd;
        }
        else
        {
            end = endM.LeftEnd;
        }
        transform.position += new Vector3(2 * end, 0);
    }

    private void Update()
    {
        transform.position = new Vector3(real.position.x + 2 * end, real.position.y, 0);
    }
}
