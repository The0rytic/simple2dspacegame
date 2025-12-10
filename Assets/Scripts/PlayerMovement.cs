using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;

    private Rigidbody2D rb;
    private float moveInputX;
    private float moveInputY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Only read input in Update
        moveInputX = Input.GetAxisRaw("Horizontal");
        moveInputY = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Apply movement in FixedUpdate
        rb.velocity = new Vector2(moveInputX * speed, moveInputY * speed);
    }
}
