using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] slimePrefabs;
    [SerializeField] Transform slimePoolPa;
    public Dictionary<string, GameObject[]> SlimeDic { get; private set; }
    private int poolSize = 30;
    public string[] SlimesNames { get; private set; }

    [SerializeField] SlimeSpawn[] spawnPoints;
    private int selectSpawnPoint;
    private int selectedSpawnPoint;

    SlimeSpawnDifficulty diff;

    private void Awake()
    {
        diff = GetComponent<SlimeSpawnDifficulty>();
        SlimeDic = new Dictionary<string, GameObject[]>();
        SlimesNames = new string[slimePrefabs.Length];
        SlimePoolMake();
        diff.Keys = SlimesNames;

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
            SlimesNames[i] = slimePrefabs[i].name;
            SlimeDic.Add(slimePrefabs[i].name, slimePool);
        }
    }
    public void SpawnSlime(string key)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject slime = SlimeDic[key][i];
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
        diff.spawnCo = null;
    }
}
