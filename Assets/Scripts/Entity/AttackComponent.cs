using UnityEngine;

[RequireComponent(typeof(Collider2D))] // Pastikan objek memiliki komponen Collider2D
public class AttackComponent : MonoBehaviour
{
    public Bullet bulletPrefab; // Properti untuk menyimpan prefab Bullet (jika diperlukan)
    public int damage = 10; // Nilai damage yang diberikan

    void Start()
    {
        // Pastikan Collider2D diatur sebagai trigger
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.isTrigger = true; // Atur collider menjadi trigger
        }
        else
        {
            Debug.LogError("Collider2D not found on this GameObject.");
        }
    }

    // Method yang dipanggil ketika objek lain memasuki trigger collider
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Cek apakah objek yang collide memiliki tag yang sama dengan objek ini
        if (collision.CompareTag(gameObject.tag))
        {
            return; // Jika sama, kembalikan tanpa melakukan apa-apa
        }

        // Cek apakah objek yang collide memiliki komponen InvincibilityComponent
        InvincibilityComponent invincibility = collision.GetComponent<InvincibilityComponent>();
        if (invincibility != null)
        {
            // Aktifkan invincibility jika belum aktif
            invincibility.TriggerInvincibility();
        }

        // Cek apakah objek yang collide memiliki komponen HitboxComponent
        HitboxComponent hitbox = collision.GetComponent<HitboxComponent>();
        if (hitbox != null && (invincibility == null || !invincibility.isInvincible))
        {
            // Jika objek tidak dalam keadaan invincible, berikan damage
            hitbox.Damage(damage);
            Debug.Log("Collided with " + collision.gameObject.name + ". Damage dealt: " + damage);
        }
    }
}
