using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the player
    private Rigidbody2D rb;  // Reference to the Rigidbody2D component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component on the player
    }

    void Update()
    {
        // Get input from the player
        float moveX = Input.GetAxisRaw("Horizontal"); // Left/Right input (A/D or arrows)
        float moveY = Input.GetAxisRaw("Vertical");   // Up/Down input (W/S or arrows)

        // Create a movement vector
        Vector2 movement = new Vector2(moveX, moveY).normalized * speed;

        // Apply movement to the Rigidbody2D
        rb.velocity = movement;
    }
}