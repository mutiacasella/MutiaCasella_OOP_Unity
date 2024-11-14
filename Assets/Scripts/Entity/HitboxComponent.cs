using UnityEngine;

[RequireComponent(typeof(Collider2D))] // Pastikan objek memiliki komponen Collider2D
public class HitboxComponent : MonoBehaviour
{
    public HealthComponent health; // Properti untuk menyimpan referensi ke HealthComponent

    void Start()
    {
        // Pastikan objek memiliki komponen HealthComponent
        health = GetComponent<HealthComponent>();
        if (health == null)
        {
            Debug.LogError("HealthComponent not found on this GameObject.");
        }
    }

    // Method Damage untuk menerima Bullet
    public void Damage(Bullet bullet)
    {
        InvincibilityComponent invincibility = GetComponent<InvincibilityComponent>();
        if (health != null && (invincibility == null || !invincibility.isInvincible))
        {
            health.Subtract(bullet.damage); // Kurangi health berdasarkan damage dari Bullet
            Debug.Log("Hit by bullet. Health reduced by: " + bullet.damage);
        }
    }

    // Method Damage untuk menerima integer
    public void Damage(int damageAmount)
    {
        InvincibilityComponent invincibility = GetComponent<InvincibilityComponent>();
        if (health != null && (invincibility == null || !invincibility.isInvincible))
        {
            health.Subtract(damageAmount); // Kurangi health dengan nilai damage yang diberikan
            Debug.Log("Hit by direct damage. Health reduced by: " + damageAmount);
        }
    }
}
