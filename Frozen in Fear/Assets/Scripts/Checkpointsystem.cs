using UnityEngine;

public class SimpleCheckpoint : MonoBehaviour
{
    private Vector3 lastCheckpoint;

    void Start()
    {
        // Set starting position as first checkpoint
        lastCheckpoint = transform.position;
    }

    void Update()
    {
        // Press 'L' to respawn
        if (Input.GetKeyDown(KeyCode.L))
        {
            transform.position = lastCheckpoint;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if we hit a checkpoint 
        if (other.CompareTag("Checkpoint"))
        {
            lastCheckpoint = transform.position;
            Debug.Log("Checkpoint saved!");
        }

    }
}