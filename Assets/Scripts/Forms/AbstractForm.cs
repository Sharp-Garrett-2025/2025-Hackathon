using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractForm : MonoBehaviour
{
    public abstract void  AnswerCheck();
    public List<GameObject> textObjects;
    public BasicChunk basicChunk;
    public bool canContinue = false;
    public Color defaultColor;
    // Start is called before the first frame update
    
    void Start()
    {
        basicChunk = GetComponent<BasicChunk>();
    }

    public void TestYesOrNo(bool value, ToggleGroup group)
    {
        var yesOrNo = value;
        if (yesOrNo == true)
        {
            group.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.green;
            group.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().color = defaultColor;
        }
        else
        {
            group.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
            group.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = defaultColor;
        }
    }

    public virtual void TestStrings()
    {
        foreach (var text in textObjects)
        {
            var textComponent = text.GetComponent<TMP_InputField>();
            if (textComponent.text == "")
            {
                canContinue = false;
            }
        }
    }
    public virtual void OnFormPressed()
    {
        AnswerCheck();
        if (canContinue)
        {
            Debug.Log("Form Passed");
            basicChunk.EndChunk();
        }
        else
        {
            Debug.Log("Please complete the current chunk before proceeding.");
        }
    }


}
