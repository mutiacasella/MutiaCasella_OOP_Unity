using UnityEngine;

public class EnemyHorizontal : MonoBehaviour
{
    public float speed = 2f;
    private Vector2 direction;

    void Start()
    {
        float spawnSide = Random.Range(0f, 1f);
        Vector2 spawnPosition;

        if (spawnSide < 0.5f)
        {
            spawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(0, Random.Range(0.2f, 0.8f)));
            spawnPosition.x -= 1f;
            direction = Vector2.right;
        }
        else
        {
            spawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(1, Random.Range(0.2f, 0.8f)));
            spawnPosition.x += 1f;
            direction = Vector2.left;
        }

        transform.position = spawnPosition;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.x < Camera.main.ViewportToWorldPoint(new Vector2(-0.1f, 0)).x ||
            transform.position.x > Camera.main.ViewportToWorldPoint(new Vector2(1.1f, 0)).x)
        {
            Destroy(gameObject);
        }
    }
}
