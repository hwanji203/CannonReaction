using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] slimePrefabs;
    [SerializeField] Transform slimePoolPa;
    Dictionary<string, GameObject[]> slimeDic;
    private int poolSize = 30;

    [SerializeField] private float spawnCoolFirst = 1;
    [SerializeField] private float spawnCoolSecond = 2;

    [SerializeField] SlimeSpawn[] spawnPoints;
    private int selectSpawnPoint;
    private int selectedSpawnPoint;

    private string slimeKey;

    private void Awake()
    {
        slimeDic = new Dictionary<string, GameObject[]>();
        SlimePoolMake();

        slimeKey = slimePrefabs[0].name;
    }

    private void Start()
    {
        StartCoroutine(SpawnSlime());
    }
    private void SlimePoolMake()
    {
        for (int i = 0; i < slimePrefabs.Length; i++)
        {
            GameObject[] slimePool = new GameObject[poolSize];
            for (int j = 0; j < poolSize; j++)
            {
                slimePool[j] = Instantiate(slimePrefabs[i], slimePoolPa);
                slimePool[j].transform.position = transform.position;
                slimePool[j].SetActive(false);
            }
            slimeDic.Add(slimePrefabs[i].name, slimePool);
        }
    }
    private IEnumerator SpawnSlime()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject slime = slimeDic[slimeKey][i];
            if (!slime.activeSelf && spawnPoints.Length != 1)
            {
                do
                {
                    selectSpawnPoint = Random.Range(0, spawnPoints.Length);
                }
                while (selectSpawnPoint == selectedSpawnPoint);
                spawnPoints[selectSpawnPoint].SpawnSlime(slime);
                selectedSpawnPoint = selectSpawnPoint;
                break;
            }
        }
        yield return new WaitForSeconds(Random.Range(spawnCoolFirst, spawnCoolSecond));

        StartCoroutine(SpawnSlime());
    }

}
