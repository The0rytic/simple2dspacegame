using UnityEngine;
using System.Collections;

public class DustSpawner : MonoBehaviour
{
    public GameObject[] dustPrefabs;  // bisa banyak dust
    public float spawnIntervalMin = 10f;
    public float spawnIntervalMax = 10f;

    void Start()
    {
        StartCoroutine(SpawnDust());
    }

    IEnumerator SpawnDust()
    {
        while (true)
        {
            // pilih dust random
            GameObject prefab = dustPrefabs[Random.Range(0, dustPrefabs.Length)];

            // spawn di atas layar
            float x = Random.Range(-3f, 3f);
            Vector3 pos = new Vector3(x, 17f, 0f);

            Instantiate(prefab, pos, Quaternion.identity);

            // tunggu waktu random supaya munculnya jarang
            float delay = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(delay);
        }
    }
}
