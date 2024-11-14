using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array dari prefab musuh
    public float spawnInterval = 2f; // Interval waktu untuk spawn musuh baru
    public int numberOfEnemiesPerSpawn = 3; // Jumlah musuh yang muncul setiap spawn

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
                // Pilih prefab musuh secara acak dari array
                int randomIndex = Random.Range(0, enemyPrefabs.Length);
                GameObject selectedEnemy = enemyPrefabs[randomIndex];

                // Tentukan posisi spawn secara acak di layar
                float spawnY = Random.Range(0.2f, 0.8f); // Atur rentang y sesuai kebutuhan
                Vector2 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(Random.value < 0.5f ? 0 : 1, spawnY));
                spawnPosition.x += spawnPosition.x < 0 ? -1f : 1f; // Posisikan di luar layar

                // Spawn musuh
                Instantiate(selectedEnemy, spawnPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnInterval);
        }

        
    }
}
