using UnityEngine;

public class InfiniteScroll : MonoBehaviour
{
    public float scrollSpeed = 0.2f;
    private float height;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        // Gerakkan background ke bawah
        transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);

        // Jika posisi background sudah lewat ATAS kamera (keluar layar)
        if (transform.position.y < cam.transform.position.y - height)
        {
            // Pindahkan langsung ke ATAS background lainnya
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y + height * 1.9f,   // Naik 2x tinggi image untuk loop
                transform.position.z
            );
        }
    }
}
