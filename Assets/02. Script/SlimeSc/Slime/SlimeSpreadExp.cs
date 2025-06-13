using System.Collections.Generic;
using UnityEngine;

public class SlimeSpreadExp : MonoBehaviour
{
    [SerializeField] private GameObject[] expPrefabs;
    [SerializeField] private Transform poolTran;
    private Stack<GameObject> expPool;
    public void SpreadExp(Vector2 position)
    {
        if (expPool.TryPop(out GameObject exp))
        {
            exp.transform.position = position;
            exp.SetActive(true);
        }
        else
        {
            exp = Instantiate(expPrefabs[Random.Range(0, expPrefabs.Length)], poolTran);
            exp.transform.position = position;
            expPool.Push(exp);
        }
    }
}
