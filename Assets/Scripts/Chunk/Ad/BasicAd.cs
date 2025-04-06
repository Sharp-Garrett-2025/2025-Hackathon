using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAd : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer videoPlayer;
    public GameObject rendererGameObject;

    public BasicChunk chunk;

    public bool canContinue = false;
    public float skipTime = 5.0f;
    public bool startAtRandomPoint = false; // New variable

    private void Awake()
    {
        chunk = GetComponent<BasicChunk>();
        rendererGameObject.SetActive(true);

        if (startAtRandomPoint && videoPlayer != null)
        {
            long randomFrame = (long)Random.Range(0, videoPlayer.frameCount);
            videoPlayer.frame = randomFrame;
        }
    }

    void Update()
    {
        if (videoPlayer != null && videoPlayer.isPrepared && videoPlayer.frame >= (long)videoPlayer.frameCount)
        {
            rendererGameObject.SetActive(false);
        }
    }

    public void OnNextPressed()
    {
        if (canContinue)
        {
            // Logic to proceed to the next chunk
            Debug.Log("Proceeding to the next chunk...");
            chunk.EndChunk();
        }
        else
        {
            Debug.Log("Please complete the current chunk before proceeding.");
        }
    }

    private Coroutine skipCoroutine;
    public GameObject skipButton;

    // Start is called before the first frame update
    void Start()
    {
        skipButton.SetActive(false);
        skipCoroutine = StartCoroutine(EnableSkipButtonAfterTime());
    }

    private IEnumerator EnableSkipButtonAfterTime()
    {
        yield return new WaitForSeconds(skipTime);
        skipButton.SetActive(true);
    }

    public void OnSkipPressed()
    {
        if (skipCoroutine != null)
        {
            StopCoroutine(skipCoroutine);
        }
        videoPlayer.Stop();
        rendererGameObject.SetActive(false);
        skipButton.SetActive(false);
        canContinue = true;
        OnNextPressed();
    }
}
