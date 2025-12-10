using UnityEngine;

public class ParallaxPlanet : MonoBehaviour
{
    public float speed = 0.4f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // kalau sudah jauh di bawah layar → destroy
        if (transform.position.y < -15f)
        {
            Destroy(gameObject);
        }
    }
}
