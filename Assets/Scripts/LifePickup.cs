using UnityEngine;

public class LifePickup : MonoBehaviour
{
    public float healAmount = 100f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.Heal(healAmount);
                Debug.Log("Player healed!");
            }

            Destroy(gameObject);
        }
    }
}
