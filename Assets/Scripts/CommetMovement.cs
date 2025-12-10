using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommetMovement : MonoBehaviour
{
    public float rotateSpeed = 100f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        rb.velocity = Vector2.down * 0.6f;
    }

    void Update()
    {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
}
