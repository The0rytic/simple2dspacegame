using UnityEngine;

public class BosSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public GameObject spawnPos;
    public int scoreThreshold = 10; // skor yang memicu boss
    private bool bossSpawned = false;

    void Update()
    {
        // Cek apakah skor sudah mencapai batas & boss belum muncul
        if (!bossSpawned && GameManager.Instance.score >= scoreThreshold)
        {
            SpawnBoss();
        }
    }

    void SpawnBoss()
    {
        float x = Random.Range(-1f, 1f);

        Instantiate(bossPrefab, spawnPos.transform.position, Quaternion.identity);
        bossSpawned = true; // supaya tidak spawn 100 kali
    }
}
