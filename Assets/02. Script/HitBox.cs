using UnityEngine;

public class HitBox : MonoBehaviour
{
    private CannonDir cannonDir;

    private void Awake()
    {
        cannonDir = GameObject.FindAnyObjectByType<CannonDir>();
    }
    void Update()
    {
        transform.rotation = Quaternion.Euler(cannonDir.MoveDir);
    }
}
