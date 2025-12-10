using UnityEngine;
using System.Collections;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject[] planetPrefabs;  // bisa banyak planet
    public float spawnIntervalMin = 60f;
    public float spawnIntervalMax = 60f;

    void Start()
    {
        StartCoroutine(SpawnPlanets());
    }

    IEnumerator SpawnPlanets()
    {
        while (true)
        {
            // pilih planet random
            GameObject prefab = planetPrefabs[Random.Range(0, planetPrefabs.Length)];

            // spawn di atas layar
            float x = Random.Range(-6f, 8f);
            Vector3 pos = new Vector3(x, 17f, 5f);

            Instantiate(prefab, pos, Quaternion.identity);

            // tunggu waktu random supaya munculnya jarang
            float delay = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(delay);
        }
    }
}
