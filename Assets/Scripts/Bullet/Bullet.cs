using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20f;
    public int damage = 10;
    private Rigidbody2D rb;
    public IObjectPool<Bullet> bulletPool;
    public Vector2 direction = Vector2.up;

    public void SetPool(IObjectPool<Bullet> pool)
    {
        bulletPool = pool;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        rb.velocity = direction * bulletSpeed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        if (bulletPool != null)
        {
            bulletPool.Release(this);
        }
    }

    private void OnDisable()
    {
        rb.velocity = Vector2.zero;
    }
}