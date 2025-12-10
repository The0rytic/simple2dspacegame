using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public GameObject cuki;
    public SpriteRenderer spriteRenderer;
    public float flashDuration = 0.05f;
    public GameObject lifePickup;
    [Range(0f, 1f)] public float dropChance = 1f;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;   
        FlashRed();

        if (currentHealth <= 0)
        {
            Die();
            Drop();
        }
    }

    void Die()
    {
        Destroy(cuki);
    }

    public void FlashRed()
    {
        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        for (int i = 0; i < 3; i++)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(flashDuration);
            
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(flashDuration);
        }
    }

    void Drop()
    {
        if (Random.value <= dropChance)
        {
        Instantiate(lifePickup, cuki.transform.position, Quaternion.identity);
        } 
    }
}