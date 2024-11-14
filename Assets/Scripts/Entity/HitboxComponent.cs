using UnityEngine;

[RequireComponent(typeof(Collider2D))] 
public class HitboxComponent : MonoBehaviour
{
    public HealthComponent health;

    void Start()
    {
        health = GetComponent<HealthComponent>();
    }

    public void Damage(Bullet bullet)
    {
        InvincibilityComponent invincibility = GetComponent<InvincibilityComponent>();
        if (health != null && (invincibility == null || !invincibility.isInvincible))
        {
            health.Subtract(bullet.damage); 
        }
    }

    public void Damage(int damageAmount)
    {
        InvincibilityComponent invincibility = GetComponent<InvincibilityComponent>();
        if (health != null && (invincibility == null || !invincibility.isInvincible))
        {
            health.Subtract(damageAmount); 
        }
    }
}
