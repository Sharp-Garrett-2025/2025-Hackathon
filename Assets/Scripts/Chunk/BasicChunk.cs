using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicChunk : MonoBehaviour
{
    public event Action OnChunkEnded;

    public void StartChunk()
    {
        // This method is called when the chunk is created
        // You can initialize your chunk here
    }

    public void EndChunk()
    {
        // This method is called when the chunk is destroyed
        // You can clean up your chunk here
        OnChunkEnded?.Invoke();
    }
}
