using System.Collections;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [Header("Weapon Settings")]
    public float speed = 5f;
    public float damage = 10f;
    public float fireRate = 1f;   // tembak setiap 1 detik
    public float destroyTime = 5f;
    public GameObject enemyBulletPrefab;

    void Start()
    {
        // Mulai menembak otomatis
        StartCoroutine(AutoShoot());
    }

    IEnumerator AutoShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(fireRate);
        }
    }

    public void Shoot()
    {
        // Spawn peluru
        GameObject enemyProjectile = Instantiate(enemyBulletPrefab, transform.position, transform.rotation);

        // Kasih velocity
        Rigidbody2D rb = enemyProjectile.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;

        // Hancurkan peluru setelah beberapa detik
        Destroy(enemyProjectile, destroyTime);
    }
}
