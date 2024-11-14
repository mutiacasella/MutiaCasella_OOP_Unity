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
}
