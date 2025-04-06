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
        if(backgroundMusic != null)
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
}
