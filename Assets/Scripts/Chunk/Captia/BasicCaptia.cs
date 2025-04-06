using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasicCaptia : MonoBehaviour
{
    public GameObject errorObject;

    public TMP_Text errorText;

    public BasicChunk chunk;

    public bool canContinue = false;

    public GameObject soundObject;

    private void Awake()
    {
        chunk = GetComponent<BasicChunk>();
        SetErrorText();
    }

    public virtual void SetErrorText()
    {
        errorText.text = "ERROR";
    }

    public void Start()
    {
        errorObject.SetActive(false);
    }

    public void OnNextPressed()
    {
        Instantiate(soundObject, transform.parent.GetComponentInParent<RectTransform>());
        if (canContinue)
        {
            // Logic to proceed to the next chunk
            Debug.Log("Proceeding to the next chunk...");
            errorObject.SetActive(false);
            chunk.EndChunk();
        }
        else
        {
            Debug.Log("Please complete the current chunk before proceeding.");
            errorObject.SetActive(true);
        }
    }
}
