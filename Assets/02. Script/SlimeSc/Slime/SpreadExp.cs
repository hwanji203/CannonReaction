using System.Collections.Generic;
using UnityEngine;

public class SpreadExp : MonoBehaviour
{
    [SerializeField] private GameObject expPrefab;
    [SerializeField] private Transform poolTran;
    public Stack<GameObject> expPool;
    private void Awake()
    {
        expPool = new Stack<GameObject>();
    }

    public void Spread(Vector2 slimePosition ,int maxSpreadExp)
    {
        for (int i = 0; i <  Random.Range(1, maxSpreadExp); i++)
        {
            if (expPool.TryPop(out GameObject exp)) 
            {
                exp.transform.position = slimePosition;
            }
            else
            {
                exp = Instantiate(expPrefab, poolTran);
                exp.transform.position = slimePosition;
            }
            exp.SetActive(true);
        }
    }
}
