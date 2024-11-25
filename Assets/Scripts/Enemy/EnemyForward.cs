using UnityEngine;

public class EnemyForward : MonoBehaviour
{
    public float speed = 2f; 

    void Start()
    {
        Vector2 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(Random.Range(0f, 1f), 1));
        spawnPosition.y += 1f;

        transform.position = spawnPosition;
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < Camera.main.ViewportToWorldPoint(new Vector2(0, -0.1f)).y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            HealthComponent healthComponent = GetComponent<HealthComponent>();
            if (healthComponent != null)
            {
                healthComponent.Subtract(1);
                
                if (healthComponent.Health <= 0)
                {
                    Die();
                }
            }

            Destroy(collision.gameObject);
        }
    }

    private void Die()
    {
        
        if (EnemySpawner.Instance != null)
        {
            EnemySpawner.Instance.OnEnemyKilled(2);
        }

        UIManager.Instance.UpdatePoints(2, 1);
        UIManager.Instance.UpdateEnemiesRemaining(UIManager.Instance.EnemiesRemaining - 1);
        Destroy(gameObject);
    }
}
