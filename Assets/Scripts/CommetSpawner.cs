using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommetSpawner : MonoBehaviour
{
    [Header("Commet Settings")]
    public GameObject CommetPrefab;

    IEnumerator SpawnCommet()
    {
        while (true)
        {
        yield return new WaitForSeconds(4f);

            float x;

            // 50% spawn kiri, 50% spawn kanan
            if (Random.value < 0.5f)
                x = Random.Range(-1f, -0.4f);   // ZONA KIRI
            else
                x = Random.Range(0.4f, 1f);     // ZONA KANAN

            GameObject commet = Instantiate(CommetPrefab, new Vector2(x, 3.9f), Quaternion.identity);

            commet.transform.rotation = Quaternion.Euler(0, 0, 180);

            Destroy(commet, 6f);

            yield return new WaitForSeconds(15f);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnCommet());
    }
}
