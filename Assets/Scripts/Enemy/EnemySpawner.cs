using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnInterval = 2f;
    public int numberOfEnemiesPerSpawn = 3;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Debug.Log("muncul");
            for (int i = 0; i < numberOfEnemiesPerSpawn; i++)
            {
                int randomIndex = Random.Range(0, enemyPrefabs.Length);
                GameObject selectedEnemy = enemyPrefabs[randomIndex];

                float spawnY = Random.Range(0.2f, 0.8f); 
                Vector2 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(Random.value < 0.5f ? 0 : 1, spawnY));
                spawnPosition.x += spawnPosition.x < 0 ? -1f : 1f; 

                Instantiate(selectedEnemy, spawnPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
