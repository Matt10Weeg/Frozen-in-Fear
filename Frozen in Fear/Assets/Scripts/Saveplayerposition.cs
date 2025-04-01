using UnityEngine;

public class SavePlayerPosition : MonoBehaviour
{
    public Transform player; // Assign your player object in the Inspector

    public void SavePosition()
    {
        PlayerPrefs.SetFloat("PlayerX", player.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.position.z);
        PlayerPrefs.Save(); // Ensure data is saved
        Debug.Log("Player position saved!");
    }
}

