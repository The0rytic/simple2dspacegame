using System.Collections;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            // Cek health di parent dulu
            EnemyHealth enemyHealth = collision.GetComponentInParent<EnemyHealth>();

            // Kalau tidak ada di parent, cek di child
            if (enemyHealth == null)
            {
                enemyHealth = collision.GetComponentInChildren<EnemyHealth>();
            }

            // Jika ketemu di parent atau child
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            
            // Hancurkan peluru setelah menabrak apapun
            Destroy(gameObject);
        }

        if (collision.CompareTag("Commet"))
        {
            // Cek health di parent dulu
            CommetHealth commetHealth = collision.GetComponentInParent<CommetHealth>();

            // Kalau tidak ada di parent, cek di child
            if (commetHealth == null)
            {
                commetHealth = collision.GetComponentInChildren<CommetHealth>();
            }

            // Jika ketemu di parent atau child
            if (commetHealth != null)
            {
                commetHealth.TakeDamage(damage);
            }
            
            // Hancurkan peluru setelah menabrak apapun
            Destroy(gameObject);
        }

        if (collision.CompareTag("Bishop"))
        {
            // Cek health di parent dulu
            BishopHealth bishopHealth = collision.GetComponentInParent<BishopHealth>();

            // Kalau tidak ada di parent, cek di child
            if (bishopHealth == null)
            {
                bishopHealth = collision.GetComponentInChildren<BishopHealth>();
            }

            // Jika ketemu di parent atau child
            if (bishopHealth != null)
            {
                bishopHealth.TakeDamage(damage);
            }
            
            // Hancurkan peluru setelah menabrak apapun
            Destroy(gameObject);
        }

        if (collision.CompareTag("Boss"))
        {
            // Cek health di parent dulu
            BosHealth bosHealth = collision.GetComponentInParent<BosHealth>();

            // Kalau tidak ada di parent, cek di child
            if (bosHealth == null)
            {
                bosHealth = collision.GetComponentInChildren<BosHealth>();
            }

            // Jika ketemu di parent atau child
            if (bosHealth != null)
            {
                bosHealth.TakeDamage(damage);
            }
            
            // Hancurkan peluru setelah menabrak apapun
            Destroy(gameObject);
        }
    }
}
