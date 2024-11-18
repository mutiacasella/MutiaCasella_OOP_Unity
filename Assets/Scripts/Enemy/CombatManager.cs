using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners;
    public float timer = 0;
    [SerializeField] private float waveInterval = 5f;
    public int waveNumber = 1;
    public int totalEnemies = 0;

    private void Start()
    {
        StartNextWave();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= waveInterval)
        {
            timer = 0;
            StartNextWave();
        }
    }

    private void StartNextWave()
    {
        totalEnemies = 0;

        foreach (var spawner in enemySpawners)
        {
            if (spawner != null)
            {
                spawner.spawnCount = spawner.defaultSpawnCount * waveNumber;
                totalEnemies += spawner.spawnCount;
                spawner.isSpawning = true;
                spawner.StartCoroutine("SpawnEnemies");
            }
        }

        waveNumber++;
    }

    public void StopAllSpawners()
    {
        foreach (var spawner in enemySpawners)
        {
            if (spawner != null)
            {
                spawner.StopSpawning();
            }
        }
    }

    public void ResetWaves()
    {
        waveNumber = 1;
        timer = 0;
        foreach (var spawner in enemySpawners)
        {
            if (spawner != null)
            {
                spawner.ResetSpawner();
            }
        }
    }
}
