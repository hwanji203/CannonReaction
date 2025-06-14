using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] slimePrefabs;
    [SerializeField] Transform slimePoolPa;
    Dictionary<string, GameObject[]> slimeDic;
    private int poolSize = 20;

    private float spawnCoolFirst = 1;
    private float spawnCoolSecond = 2;
    private Coroutine spawnCoroutine;

    [SerializeField] SlimeSpawn[] spawnPoints;
    private int selectSpawnPoint;
    private int selectedSpawnPoint;

    private void Awake()
    {
        slimeDic = new Dictionary<string, GameObject[]>();
        SlimePoolMake();
    }
    private void Start()
    {
        selectSpawnPoint = Random.Range(0, spawnPoints.Length);
        selectedSpawnPoint = selectSpawnPoint;
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

    private void Update()
    {
        if (spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(SpawnSlime());
        }
    }

    private IEnumerator SpawnSlime()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject slime = slimeDic["BasicSlime"][i];
            if (!slime.activeSelf)
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
        spawnCoroutine = null;
    }

}
