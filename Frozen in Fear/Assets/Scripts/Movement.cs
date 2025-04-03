using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float speed = 6f;          // Bewegings snelheid van de speler
    public float turnSpeed = 100f;    // Snelheid van de rotatie
    private Rigidbody rb;             // Referentie naar de Rigidbody component

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Krijg de Rigidbody component van de speler
    }

    void FixedUpdate()
    {
        // Krijg de input van de speler
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right arrows
        float moveVertical = Input.GetAxisRaw("Vertical");     // W/S or Up/Down arrows

        // Bereken beweging directie gerelateerd naar de speler's voorwaardse directie
        Vector3 movement = (transform.forward * moveVertical + transform.right * moveHorizontal).normalized * speed;

        // Pas movement toe op de Rigidbody
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);

        // B rotatie (optioneel, op basis van horizontale invoer)
        float rotation = moveHorizontal * turnSpeed * Time.fixedDeltaTime;
        Quaternion turn = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * turn);
    }
}