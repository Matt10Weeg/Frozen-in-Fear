using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Scene 2";
    
    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
