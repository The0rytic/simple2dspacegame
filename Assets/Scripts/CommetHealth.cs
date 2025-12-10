using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommetHealth : MonoBehaviour
{
    public float maxHealth = 60f;
    private float currentHealth;
    public GameObject Commet;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(Commet);
    }
}