using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public SpriteRenderer spriteRenderer;
    public float flashDuration = 0.05f;
    public HealthUI HealthUI;
    public GameOverUI gameOverUI;

    private void Start()
    {
        currentHealth = maxHealth;
        HealthUI.UpdateHP(currentHealth, maxHealth);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        FlashRed();

        if (currentHealth <= 0)
        {
            Die();
        }

        HealthUI.UpdateHP(currentHealth, maxHealth);
    }

    void Die()
    {
        Debug.Log("Player Mati!");
        Destroy(gameObject);  // Player hilang
        GameManager.Instance.GameOver();  // Panggil Game Over dari GameManager
        gameOverUI.ShowGameOver(); // Tampilkan UI Game Over
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Bishop") || collision.gameObject.CompareTag("Commet"))
        {
            TakeDamage(10f); // Contoh: Kurangi health sebesar 10 saat terkena musuh
        }
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

    public void Heal(float amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        HealthUI.UpdateHP(currentHealth, maxHealth);
    }
}