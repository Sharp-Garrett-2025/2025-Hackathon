using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    public GameObject content; // The content GameObject inside the Scroll View
    public GameObject chunkPrefab; // The prefab for the website chunk
    public List<GameObject> chunks; // List to hold the chunk objects
    private int currentChunk = 0;
    private List<GameObject> displayedChunks = new List<GameObject>();

    private void Start()
    {
        AddChunk(chunks[currentChunk]); // Add an initial chunk on start
    }

    // Method to add a chunk to the list and update the webpage
    public void AddChunk(GameObject chunk)
    {
        // Instantiate a new chunk and add it to the content
        GameObject newChunk = Instantiate(chunk, content.transform);
        displayedChunks.Add(newChunk);
        newChunk.GetComponent<BasicChunk>().StartChunk();
        newChunk.GetComponent<BasicChunk>().OnChunkEnded += () =>
        {

            if(currentChunk >= chunks.Count - 1)
            {
                // If the last chunk is reached, do not add more
                return;
            }
            AddChunk(chunks[currentChunk]); // Add a new chunk when the current one ends
        };
        // Optionally, you can set the chunk's properties here
        // newChunk.GetComponent<YourChunkComponent>().SetProperties(...);

        // Update the content size
        currentChunk++;
        UpdateContentSize();
    }

    // Method to update the content size
    private void UpdateContentSize()
    {
        // Force the content to update its size
        LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
    }
}
