using UnityEngine;

public class LoadPlayerPosition : MonoBehaviour
{
    public Transform player; // Assign your player object in the Inspector

    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerX")) // Check if position exists
        {
            float x = PlayerPrefs.GetFloat("PlayerX");
            float y = PlayerPrefs.GetFloat("PlayerY");
            float z = PlayerPrefs.GetFloat("PlayerZ");

            player.position = new Vector3(x, y, z);
            Debug.Log("Player position loaded!");
        }
    }
}

