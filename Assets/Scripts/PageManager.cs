using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    public GameObject content; // The content GameObject inside the Scroll View
    public GameObject chunkPrefab; // The prefab for the website chunk
    private List<GameObject> chunks = new List<GameObject>();

    private void Start()
    {
         AddChunk(); // Add an initial chunk on start
    }

    // Method to add a chunk to the list and update the webpage
    public void AddChunk()
    {
        // Instantiate a new chunk and add it to the content
        GameObject newChunk = Instantiate(chunkPrefab, content.transform);
        chunks.Add(newChunk);

        // Optionally, you can set the chunk's properties here
        // newChunk.GetComponent<YourChunkComponent>().SetProperties(...);

        // Update the content size
        UpdateContentSize();
    }

    // Method to update the content size
    private void UpdateContentSize()
    {
        // Force the content to update its size
        LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
    }
}
