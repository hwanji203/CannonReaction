using UnityEngine;

public class FireSpotManager : MonoBehaviour
{
    [SerializeField] private GameObject leftSpot;
    [SerializeField] private GameObject rightSpot;
    [SerializeField] private GameObject leftCannon;
    [SerializeField] private GameObject rightCannon;
    [SerializeField] private GameObject hitBox;
    private CannonDir cannonDir;
    private float leftEnd;

    private void Awake()
    {
        cannonDir = GameObject.FindAnyObjectByType<CannonDir>();
        leftEnd = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
    }
    private void Update()
    {
        ChangeSpot();
    }

    private void ChangeSpot()
    {
        if (rightSpot.gameObject.transform.position.x < leftEnd)
        {
            cannonDir.FireSpot = leftSpot.gameObject.transform;
            hitBox.transform.position = leftCannon.gameObject.transform.position;
        }
        else
        {
            cannonDir.FireSpot = rightSpot.gameObject.transform;
            hitBox.transform.position = rightCannon.gameObject.transform.position;
        }
    }
}
