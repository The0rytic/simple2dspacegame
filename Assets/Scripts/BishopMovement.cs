using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopMovement : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
        else Debug.LogWarning("Player tidak ditemukan! Tag 'Player' ?");
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            // hanya ikut X pemain, Y turun konstan
            float dirX = (player.position.x - transform.position.x);
            // buat normalisasi X supaya speed proporsional
            dirX = Mathf.Clamp(dirX, -5f, 5f); // mencegah loncat terlalu besar
            float xVel = (dirX == 0) ? 0f : Mathf.Sign(dirX) * Mathf.Min(Mathf.Abs(dirX), 1f) * speed;

            rb.velocity = new Vector2(xVel, -speed);
        }
        else
        {
            rb.velocity = Vector2.down * speed;
        }
    }
}
