using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosHealth : MonoBehaviour
{
    public float maxHealth = 500f;
    private float currentHealth;
    public GameObject boss;
    public SpriteRenderer spriteRenderer;
    public float flashDuration = 0.05f;

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
        }
    }

    void Die()
    {
        GameManager.Instance.AddScore(10);
        
        Destroy(boss);
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
}