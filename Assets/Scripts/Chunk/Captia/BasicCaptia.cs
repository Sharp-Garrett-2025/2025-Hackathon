using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCaptia : MonoBehaviour
{

    public BasicChunk chunk;

    public bool canContinue = false;

    private void Awake()
    {
        chunk = GetComponent<BasicChunk>();
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
}
