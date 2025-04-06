using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Reference to the background music AudioSource
    public AudioSource backgroundMusic;

    // List of background music tracks
    public List<AudioClip> musicTracks;
    private int currentTrackIndex = 0;

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
        if (backgroundMusic != null && musicTracks.Count > 0)
        {
            backgroundMusic.clip = musicTracks[currentTrackIndex];
            backgroundMusic.Play();
            backgroundMusic.loop = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!backgroundMusic.isPlaying)
        {
            interuptStarted = true;
            StartCoroutine(WaitAndPlayNextTrack());
        }
    }

    // Coroutine to wait before playing the next track
    IEnumerator WaitAndPlayNextTrack()
    {
        yield return new WaitForSeconds(waitTime);
        if (backgroundMusic != null)
        {
            yield break;
        }
        else
            PlayNextTrack();
    }

    // Function to play the next track in the list
    void PlayNextTrack()
    {
        currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Count;
        backgroundMusic.clip = musicTracks[currentTrackIndex];
        backgroundMusic.Play();
        interuptStarted = false;
    }

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
