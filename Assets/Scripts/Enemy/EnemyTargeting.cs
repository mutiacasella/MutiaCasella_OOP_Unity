using UnityEngine;

public class EnemyTargeting : MonoBehaviour
{
    public float speed = 3f;
    private Transform playerTransform;

    void Update()
    {
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
        }

        if (playerTransform != null)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

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
            EnemySpawner.Instance.OnEnemyKilled(3);
        }

        UIManager.Instance.UpdatePoints(3, 1);
        UIManager.Instance.UpdateEnemiesRemaining(UIManager.Instance.EnemiesRemaining - 1);
        Destroy(gameObject);
    }
}
