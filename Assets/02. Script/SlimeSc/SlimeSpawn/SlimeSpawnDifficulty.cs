using UnityEngine;
using System.Collections;

public class SlimeSpawnDifficulty : MonoBehaviour
{
    private SlimeSpawnManager spawner;
    public Coroutine spawnCo { get; set; }

    public string[] Keys { get; set; }

    [Header("Spawn Timing")]
    [SerializeField] private float firstSpawnTime = 2f;
    [SerializeField] private float lastSpawnTime = 0.5f;
    [field : SerializeField] public float Playtime { get; private set; } = 120f;
    [field: SerializeField] public int Difficulty { get; set; } = 1;

    private void Awake()
    {
        spawner = GetComponent<SlimeSpawnManager>();
    }
    private void Update()
    {
        IncreaseDifficulty();
        if (spawnCo == null && Keys != null)
        {
            spawnCo = StartCoroutine(SpawnSlime(GetKey(), GetTime()));
        }
    }

    private void IncreaseDifficulty()
    {
        float t = Mathf.Clamp01(TimeManager.Instance.GetTime() / Playtime);
        Difficulty = Mathf.Min((int)Mathf.Lerp(0, Keys.Length - 1, t), Keys.Length - 1);
    }

    private float GetTime()
    {
        float t = Mathf.Min(TimeManager.Instance.GetTime() / Playtime, 1f);
        return Mathf.Lerp(firstSpawnTime, lastSpawnTime, t);
    }

    private string GetKey()
    {
        float value = Random.value;
        int keyCount = Mathf.Min(Difficulty + 1, Keys.Length);
        float step = 1f / keyCount;

        for (int i = 0; i < keyCount; i++)
        {
            if (value < step * (i + 1))
                return Keys[i];
        }

        Debug.LogWarning("GetKey¿¡¼­ fallback");
        return Keys[Keys.Length - 1];
    }

    private IEnumerator SpawnSlime(string key, float delay)
    {
        spawner.SpawnSlime(key);
        yield return new WaitForSeconds(delay);
        spawnCo = null;
    }
}
