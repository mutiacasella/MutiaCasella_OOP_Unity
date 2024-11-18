using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public Enemy spawnedEnemy;

    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 3;
    public int totalKill = 0;
    private int totalKillWave = 0;

    [SerializeField] private float spawnInterval = 3f;

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0;
    public int defaultSpawnCount = 1;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;

    public CombatManager combatManager;

    public bool isSpawning = false;

    private void Start()
    {
        spawnCount = defaultSpawnCount;
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        isSpawning = true;
        while (isSpawning)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                if (spawnedEnemy != null)
                {
                    Instantiate(spawnedEnemy, transform.position, Quaternion.identity);
                }
            }

            totalKillWave += spawnCount;
            if (totalKillWave >= minimumKillsToIncreaseSpawnCount)
            {
                totalKillWave = 0;
                spawnCount += multiplierIncreaseCount * spawnCountMultiplier;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StopSpawning()
    {
        isSpawning = false;
        StopAllCoroutines();
    }

    public void ResetSpawner()
    {
        spawnCount = defaultSpawnCount;
        totalKill = 0;
        totalKillWave = 0;
    }
}