using System.Collections;
using UnityEngine;

public class BishopWeapon : MonoBehaviour
{
    public float speed = 4f;
    public float fireRate = 0.5f;
    public float destroyTime = 10f;
    public GameObject bishopBulletPrefab;

    // offset posisi spawn peluru (agar tidak tumpuk di dalam body)
    public Vector2 spawnOffset = new Vector2(0f, -0.6f);

    void Start()
    {
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

    void Shoot()
    {

        if (bishopBulletPrefab == null)
        {
            Debug.LogWarning("bishopBulletPrefab belum di-assign di Inspector!");
            return;
        }

        Vector3 spawnPos = transform.position + (Vector3)spawnOffset;
        GameObject bullet = Instantiate(bishopBulletPrefab, spawnPos, Quaternion.identity);

        // set visual rotation supaya menghadap bawah (opsional)
        bullet.transform.rotation = Quaternion.Euler(0, 0, 180);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning("Prefab peluru tidak punya Rigidbody2D!");
        }
        else
        {
            rb.velocity = Vector2.down * speed;
        }

        // cegah peluru kena collider musuh yang spawn bersamaan
        Collider2D bulletCol = bullet.GetComponent<Collider2D>();
        Collider2D myCol = GetComponent<Collider2D>();
        if (bulletCol != null && myCol != null)
        {
            Physics2D.IgnoreCollision(bulletCol, myCol);
        }

        // jika ingin ignore collision dengan semua children colliders juga:
        Collider2D[] myCols = GetComponentsInChildren<Collider2D>();
        if (bulletCol != null && myCols.Length > 0)
        {
            foreach (var c in myCols) Physics2D.IgnoreCollision(bulletCol, c);
        }

        Destroy(bullet, destroyTime);
    }
}
