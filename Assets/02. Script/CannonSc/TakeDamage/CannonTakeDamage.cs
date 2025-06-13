using UnityEngine;

public class CannonTakeDamage : MonoBehaviour
{
    private CannonEvent cannon;

    private void Awake()
    {
        cannon = GetComponent<CannonEvent>();
    }

    private void Start()
    {
        cannon.TakeDamageEvent += TakeDamage;
    }
    public void TakeDamage()
    {
        Debug.Log("아이고 나 죽네");
    }
}
