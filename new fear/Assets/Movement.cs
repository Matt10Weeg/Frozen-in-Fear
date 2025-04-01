using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 moveDir;
    public float moveSpeed = 5f; // Bewegingssnelheid
    public Vector3 bodyRotate;
    public float rotateSpeed = 300f; // Rotatiesnelheid
    public Transform cam; // Camera referentie

    private Vector3 camRotate; // Voor camera rotatie

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Vergrendel cursor
        if (cam == null) Debug.LogError("Camera niet ingesteld in Inspector!");
    }

    void Update()
    {
        // Beweging input
        moveDir.x = Input.GetAxisRaw("Horizontal"); // A/D
        moveDir.z = Input.GetAxisRaw("Vertical");   // W/S

        // Beweging relatief aan camera-oriëntatie
        Vector3 move = cam.TransformDirection(moveDir).normalized * moveSpeed * Time.deltaTime;
        move.y = 0f; // Geen verticale beweging
        transform.Translate(move, Space.World);

        // Rotatie input
        bodyRotate.y = Input.GetAxisRaw("Mouse X"); // Horizontaal draaien
        camRotate.x = -Input.GetAxisRaw("Mouse Y"); // Verticaal kantelen

        // Draai lichaam en camera
        transform.Rotate(bodyRotate * rotateSpeed * Time.deltaTime);
        if (cam != null) cam.Rotate(camRotate * rotateSpeed * Time.deltaTime);
    }
}