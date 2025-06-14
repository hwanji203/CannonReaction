using System.Collections;
using UnityEngine;

public class ExpEnable : MonoBehaviour
{
    [SerializeField] private float disableTime = 1f;

    private SpreadExp spreadExp;

    private void Awake()
    {
        spreadExp = GameObject.FindAnyObjectByType<SpreadExp>();
    }

    private void OnEnable()
    {
        StartCoroutine(ExpDisable());
    }

    private IEnumerator ExpDisable()
    {
        yield return new WaitForSeconds(disableTime);
        spreadExp.expPool.Push(gameObject);
        gameObject.SetActive(false);
    }
}
