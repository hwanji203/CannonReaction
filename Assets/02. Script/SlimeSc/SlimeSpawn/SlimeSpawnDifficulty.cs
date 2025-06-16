using UnityEngine;
using System.Collections;

public class SlimeSpawnDifficulty : MonoBehaviour
{
    private SlimeSpawnManager spawner;
    public Coroutine spawnCo { get; set; }

    public string[] Keys { get; set; }
    [SerializeField] private int moreDiffTime = 5;

    [Range(1, 5)]
    [SerializeField] private int difficulty = 1;

    private int maxDifficulty = 5;
    private void Awake()
    {
        spawner = GetComponent<SlimeSpawnManager>();
    }
    private void Update()
    {
        if (spawnCo == null && Keys != null)
        {
            spawnCo = StartCoroutine(spawner.SpawnSlime(GetKey(), GetTime()));
        }
    }
    private void Start()
    {
        StartCoroutine(IncreaseDifficulty());
    }

    private IEnumerator IncreaseDifficulty()
    {
        while (difficulty < maxDifficulty)
        {
            yield return new WaitForSeconds(moreDiffTime);
            difficulty++;
        }
    }

    private float GetTime()
    {
        switch (difficulty)
        {
            case 1:
                return Random.Range(3f, 4f);
            case 2:
                return Random.Range(2.75f, 3.5f);
            case 3:
                return Random.Range(2.25f, 3f);
            case 4:
                return Random.Range(1.75f, 2.5f);
            case 5:
                return Random.Range(1, 1.75f);
            default:
                Debug.Log("GetTime 오류");
                return Random.Range(0.8f, 1.8f);
        }
    }

    private string GetKey()
    {
        float value = Random.Range(0f, 1f);

        switch (difficulty)
        {
            case 1:
                return value < 0.8f ? Keys[0] : Keys[1];
            case 2:
                return value < 0.6f ? Keys[0] : Keys[1];
            case 3:
                return value < 0.4f ? Keys[0] : Keys[1];
            case 4:
                return value < 0.3f ? Keys[0] : value < 0.8f ? Keys[1] : Keys[2];
            case 5:
                return value < 0.15f ? Keys[0] : value < 0.4f ? Keys[1] : Keys[2];
            default:
                Debug.Log("GetKey 오류");
                return Keys[Random.Range(0, Keys.Length)];
        //        #region 개발자 모드
        //        float value = Random.Range(0f, 1f);

        //switch (difficulty)
        //{
        //    case 1:
        //    case 2:
        //    case 3:
        //    case 4:
        //    case 5:
        //        return value < 0.15f ? Keys[0] : value < 0.4f ? Keys[1] : Keys[2];
        //    default:
        //        Debug.Log("GetKey 오류");
        //        return Keys[Random.Range(0, Keys.Length)];
        //        #endregion 개발자 모드
        }
    }
}
