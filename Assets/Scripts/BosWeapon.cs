using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class BosWeapon : MonoBehaviour
{
    [Header("Weapon Settings")]
    public float speed = 5f;
    public float damage = 10f;
    public float fireRate = 1f;   // tembak setiap 1 detik
    public float destroyTime = 5f;
    public GameObject enemyBulletPrefab;
    private BosMovement bosMovement;

    void Start()
    {
        bosMovement = GetComponentInParent<BosMovement>();
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
        GameObject bullet = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        SpriteRenderer sr = GetComponentInParent<SpriteRenderer>();

        Vector2 shootDir;

        // arah dasar sesuai arah bos
        if (sr.flipY)
            shootDir = Vector2.up;      // menghadap atas
        else
            shootDir = Vector2.down;    // menghadap bawah

        // BALIK 180°
        shootDir = -shootDir;

        rb.velocity = shootDir * speed;

        Destroy(bullet, destroyTime);
    }

}