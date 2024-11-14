using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public float speed = 2f; 
    public GameObject bulletPrefab; 
    public Transform bulletSpawnPoint; 
    public float shootInterval = 2f; 
    private float shootTimer = 0f;

    private Vector2 direction;

    void Start()
    {
        float spawnSide = Random.Range(0f, 1f);
        Vector2 spawnPosition;

        if (spawnSide < 0.5f)
        {
            spawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(0, Random.Range(0f, 1f)));
            spawnPosition.y = 3;
            direction = Vector2.right;
        }
        else
        {
            spawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(1, Random.Range(0f, 1f)));
            spawnPosition.y = 3;
            direction = Vector2.left;
        }

        transform.position = spawnPosition;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.x < Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x ||
            transform.position.x > Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x)
        {
            direction = -direction; 
        }

        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        }
    }
}
