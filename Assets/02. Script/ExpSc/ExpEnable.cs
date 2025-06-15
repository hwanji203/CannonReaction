using System.Collections;
using UnityEngine;

public class ExpEnable : MonoBehaviour
{
    [SerializeField] private float disableTime = 1f;

    private SpreadExp spreadExp;

    public bool IsMoving { get; set; } = false;

    private float lifeTime = 0;
    private void Awake()
    {
        spreadExp = GameObject.FindAnyObjectByType<SpreadExp>();
    }

    private void Update()
    {
        if (!IsMoving)
        {
            lifeTime += Time.deltaTime;
        }
        if (lifeTime > disableTime)
        {
            PushExp();
        }
    }

    public void PushExp()
    {
        lifeTime = 0;
        IsMoving = false;
        spreadExp.expPool.Push(gameObject);
    }

}
