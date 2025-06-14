using System.Collections.Generic;
using UnityEngine;

public class SlimeSpreadExp : MonoBehaviour
{
    [SerializeField] private GameObject expPrefab;
    private Transform poolTran;
    private Stack<GameObject> expPool;

    [SerializeField] private int maxSpreadExp = 3;

    private void Awake()
    {
        poolTran = GameObject.Find("ExpPool").transform;

        expPool = new Stack<GameObject>();
    }

    public void SpreadExp()
    {
        for (int i = 0; i <  Random.Range(1, maxSpreadExp); i++)
        {
            if (expPool.TryPop(out GameObject exp)) 
            {
                exp.transform.position = transform.position;
                exp.SetActive(true);
            }
            else
            {
                exp = Instantiate(expPrefab, poolTran);
                exp.transform.position = transform.position;
                exp.SetActive(true);
            }
        }
    }
}
