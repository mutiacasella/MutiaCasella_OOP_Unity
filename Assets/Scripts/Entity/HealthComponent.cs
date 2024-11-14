using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    // Properti untuk menyimpan nilai health maksimal dan current health
    public int maxHealth = 100;
    private int health;

    // Getter untuk properti health
    public int Health
    {
        get { return health; }
    }

    void Start()
    {
        // Inisialisasi nilai health dengan nilai maxHealth saat start
        health = maxHealth;
    }

    // Method untuk mengurangi nilai health
    public void Subtract(int damage)
    {
        health -= damage;

        // Cek jika health kurang dari atau sama dengan 0, hancurkan object
        if (health <= 0)
        {
            health = 0; // Pastikan nilai health tidak negatif
            Destroy(gameObject);
            Debug.Log("Object destroyed because health reached 0");
        }
    }
}
