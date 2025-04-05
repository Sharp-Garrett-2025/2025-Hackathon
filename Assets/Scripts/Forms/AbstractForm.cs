using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class AbstractForm : MonoBehaviour
{
    public abstract void  AnswerCheck();

    public BasicChunk basicChunk;
    public bool canContinue = false;
    // Start is called before the first frame update
    
    void Start()
    {
        basicChunk = GetComponent<BasicChunk>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnFormPressed()
    {
        if (canContinue)
        {
            basicChunk.EndChunk();
        }
        else
        {
            Debug.Log("Please complete the current chunk before proceeding.");
        }
    }


}
