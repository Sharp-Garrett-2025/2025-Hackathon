using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Function to load a scene
    public void LoadScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Function to exit the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
