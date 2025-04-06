using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Form2 : AbstractForm
{

    public ToggleGroup dataGroup;
    public ToggleGroup clickFruadGroup;
    public ToggleGroup entityGroup;
    public Image clickFruadImage;
    public string demensionalEntity;
    public bool? multiDimensionalEntity;
    public bool? clickFruad;
    // Start is called before the first frame update
    void Start()
    {
        if (responseSheet == null)
            responseSheet = GameObject.Find("ResponseSheet").GetComponent<ResponseSheet>();
        defaultColor = clickFruadImage.color;
        canContinue = false;
        multiDimensionalEntity = null;
        clickFruad = null;
        demensionalEntity = "";

    }

    public void DemensionalEntity(string value)
    {
        demensionalEntity = value;
    }
    public void ClickFruadGroup(bool value)
    {
        TestYesOrNo(value, clickFruadGroup);
        clickFruad = value;
    }
    public void EntityGroup(bool value)
    {
        TestYesOrNo(value, entityGroup);
        multiDimensionalEntity = value;
    }

    public override void AnswerCheck()
    {
        foreach (var text in textObjects)
        {
            var textComponent = text.GetComponent<TMP_InputField>();
            if (textComponent.text == "")
            {
                canContinue = false;
            }
        }
        if (clickFruad == null)
        {
            canContinue = false;
        }
        else if (multiDimensionalEntity == null)
        {
            canContinue = false;
        }
        else
        {
            responseSheet.demensionalEntity = demensionalEntity;
            responseSheet.clickFruad = clickFruad;
            responseSheet.demensionalEntity = demensionalEntity;
            canContinue = true;
        }
    }

}
