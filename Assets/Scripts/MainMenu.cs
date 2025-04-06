using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Reference to the background music AudioSource
    public AudioSource backgroundMusic;

    // Time to wait before playing the next track
    public float waitTime = 5.0f;

    public bool interuptStarted = false;

    // Reference to the fade transition animator
    public FadeTransition fadeTransition;

    // Function to load a scene
    public void LoadScene()
    {
        StartCoroutine(FadeAndLoadScene("GameScene"));
    }

    // Function to exit the game
    public void ExitGame()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame




    // Coroutine to handle scene fade transition and loading
    IEnumerator FadeAndLoadScene(string sceneName)
    {
        fadeTransition.FadeOut();
        yield return new WaitForSeconds(1.0f); // Adjust the duration to match the fade out animation

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
