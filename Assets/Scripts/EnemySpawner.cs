using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject EnemyPrefab;

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float x = Random.Range(-1f, 1f);

            // Spawn musuh
            GameObject enemy = Instantiate(EnemyPrefab, new Vector2(x, 3.8f), Quaternion.identity);
            enemy.transform.rotation = Quaternion.Euler(0, 0, 180);

            // Ambil script EnemyWeapon dari musuh
            EnemyWeapon weapon = enemy.GetComponent<EnemyWeapon>();

            // Hancurkan musuh setelah 15 detik
            Destroy(enemy, 15f);

            yield return new WaitForSeconds(2f);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
}
