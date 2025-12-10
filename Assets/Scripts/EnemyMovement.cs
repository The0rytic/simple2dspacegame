using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector2.down * 1f;
    }
}
