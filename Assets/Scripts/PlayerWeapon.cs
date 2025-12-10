using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public float speed = 10f;
    public float destroyTime = 2f;
    public GameObject projectilePrefab;
    public AudioClip shootSFX;
    private AudioSource audiosrc;

    void Start()
    {
        audiosrc = GetComponent<AudioSource>();
    }
    
    
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // klik kiri
        {
            Shoot();
        }
    }

    void Shoot()
    {
        audiosrc.PlayOneShot(shootSFX);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector2 direction = (mousePos - transform.position).normalized;

        // --- Peluru spawn sedikit maju agar tidak kena player ---
        Vector3 spawnPos = transform.position + (Vector3)direction * 0.7f;

        GameObject projectile = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;

        // Rotasi peluru agar menghadap arah mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(0, 0, angle - 90);

        Destroy(projectile, destroyTime);
    }
}
