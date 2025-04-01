using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float speed = 6f;          // Movement speed of the player
    public float turnSpeed = 100f;    // Speed of rotation
    private Rigidbody rb;             // Reference to the Rigidbody component

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component on the player
    }

    void FixedUpdate()
    {
        // Get input from the player
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right arrows
        float moveVertical = Input.GetAxisRaw("Vertical");     // W/S or Up/Down arrows

        // Calculate movement direction relative to the player's forward direction
        Vector3 movement = (transform.forward * moveVertical + transform.right * moveHorizontal).normalized * speed;

        // Apply movement to the Rigidbody
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);

        // Handle rotation (optional, based on horizontal input)
        float rotation = moveHorizontal * turnSpeed * Time.fixedDeltaTime;
        Quaternion turn = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * turn);
    }
}