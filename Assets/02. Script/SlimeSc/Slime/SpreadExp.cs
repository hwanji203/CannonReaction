using System.Collections.Generic;
using UnityEngine;

public class SpreadExp : MonoBehaviour
{
    [SerializeField] private GameObject expPrefab;
    private Transform poolTran;
    public Stack<GameObject> expPool;

    [SerializeField] private int maxSpreadExp = 3;
    private void Awake()
    {
        poolTran = GameObject.Find("ExpPool").transform;

        expPool = new Stack<GameObject>();
    }

    public void Spread(Vector2 slimePosition)
    {
        for (int i = 0; i <  Random.Range(1, maxSpreadExp); i++)
        {
            if (expPool.TryPop(out GameObject exp)) 
            {
                Debug.Log("pop 성공");
                exp.transform.position = slimePosition;
                exp.SetActive(true);
            }
            else
            {
                Debug.Log("pop 실패");
                exp = Instantiate(expPrefab, poolTran);
                exp.transform.position = slimePosition;
                exp.SetActive(true);
            }
        }
    }
}
