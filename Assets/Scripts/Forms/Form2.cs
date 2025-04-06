using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Form2 : AbstractForm
{

    // Start is called before the first frame update
    void Start()
    {
        canContinue = false;
    }
    public override void AnswerCheck()
    {
        canContinue = true;
        foreach (var text in textObjects)
        {
            var textComponent = text.GetComponent<TMP_InputField>();
            if (textComponent.text == "")
            {
                canContinue = false;
            }
        }
    }

}
