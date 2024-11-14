using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 100;
    private int health;

    public int Health
    {
        get { return health; }
    }

    void Start()
    {
        health = maxHealth;
    }

    public void Subtract(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
    }
}