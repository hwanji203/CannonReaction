using System.Collections;
using UnityEngine;

public class ExpEnable : MonoBehaviour
{
    [SerializeField] private float disableTime = 1f;

    private void OnEnable()
    {
        StartCoroutine(ExpDisable());
    }

    private IEnumerator ExpDisable()
    {
        yield return new WaitForSeconds(disableTime);
        gameObject.SetActive(false);
    }
}
