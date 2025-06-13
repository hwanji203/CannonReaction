using System.Collections;
using UnityEngine;

public class SlimeSpawn : MonoBehaviour
{
    [SerializeField] private float areaSize;

    private float spawnAreaLeft;
    private float spawnAreaRight;

    private void Awake()
    {
        spawnAreaLeft = transform.position.x - areaSize / 2;
        spawnAreaRight = transform.position.x + areaSize / 2;
    }

    public void SpawnSlime(GameObject slimePrefab)
    {
        slimePrefab.SetActive(true);
        slimePrefab.transform.position = new Vector2(Random.Range(spawnAreaLeft, spawnAreaRight), transform.position.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector2(transform.position.x - areaSize /2, transform.position.y),
            new Vector2(transform.position.x + areaSize / 2, transform.position.y));
    }
}
