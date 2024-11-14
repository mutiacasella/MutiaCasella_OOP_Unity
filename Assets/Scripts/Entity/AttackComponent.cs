using UnityEngine;

[RequireComponent(typeof(Collider2D))] 
public class AttackComponent : MonoBehaviour
{
    public Bullet bulletPrefab; 
    public int damage = 10;

    void Start()
    {
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.isTrigger = true; 
        }
        else
        {
            Debug.LogError("Collider2D not found on this GameObject.");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(gameObject.tag))
        {
            return;
        }

        InvincibilityComponent invincibility = collision.GetComponent<InvincibilityComponent>();
        if (invincibility != null)
        {
            invincibility.TriggerInvincibility();
        }

        HitboxComponent hitbox = collision.GetComponent<HitboxComponent>();
        if (hitbox != null && (invincibility == null || !invincibility.isInvincible))
        {
            hitbox.Damage(damage);
            Debug.Log("Collided with " + collision.gameObject.name + ". Damage dealt: " + damage);
        }
    }
}
