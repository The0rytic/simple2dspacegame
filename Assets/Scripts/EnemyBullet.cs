using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag("Player"))
        {
            // Cari script health di object itu, parent, atau anak-nya
            PlayerHealth playerHealth = 
                collision.GetComponent<PlayerHealth>() ??
                collision.GetComponentInParent<PlayerHealth>() ??
                collision.GetComponentInChildren<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
