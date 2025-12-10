using System.Collections;
using UnityEngine;

public class BishopSpawner : MonoBehaviour
{
    public GameObject BishopPrefab;
    public float spawnInterval = 5f;
    public float spawnY = 5f;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            float x = Random.Range(-1f, 1f);
            Vector2 pos = new Vector2(x, spawnY);

            // spawn dengan rotasi prefab aslinya (Quaternion.identity preserves prefab rotation 0)
            GameObject bishop = Instantiate(BishopPrefab, pos, Quaternion.identity);

            // jangan paksa rotation di sini (menghapus baris yang memaksa 180)
            Destroy(bishop, 15f);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
