using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Form4 : AbstractForm
{
    public Image coinImage;
    public ToggleGroup taxGroup;
    public ToggleGroup soulGroup;
    public ToggleGroup iAmGroup;
    bool? quantumTaxEvasion = null;
    bool? fabricManipulator = null;
    bool? legalEntityBinding = null;
    public float quantCoin, spaceValue, eldritchValue, demonicValue;

    public void TaxGroup(bool value)
    {
        TestYesOrNo(value, taxGroup);
        quantumTaxEvasion = value;
    }

    public void SoulGroup(bool value)
    {
        TestYesOrNo(value, soulGroup);
        fabricManipulator = value;
    }

    public void IAmGroup(bool value)
    {
        TestYesOrNo(value, iAmGroup);
        legalEntityBinding = value;
    }



    // Start is called before the first frame update
    void Start()
    {
        if (responseSheet == null)
            responseSheet = GameObject.Find("ResponseSheet").GetComponent<ResponseSheet>();
        defaultColor = coinImage.color;
        canContinue = false;
        quantCoin = 0.0f;
        spaceValue = 0.0f;
        eldritchValue = 0.0f;
        demonicValue = 0.0f;

    }

    public override void AnswerCheck()
    {
        var textComponent = textObjects[0].GetComponent<TMP_InputField>();
        quantCoin = float.Parse(textComponent.text);
        textComponent = textObjects[1].GetComponent<TMP_InputField>();
        spaceValue = float.Parse(textComponent.text);
        textComponent = textObjects[2].GetComponent<TMP_InputField>();
        eldritchValue = float.Parse(textComponent.text);
        textComponent = textObjects[3].GetComponent<TMP_InputField>();
        demonicValue = float.Parse(textComponent.text);
        float totalValue = quantCoin + spaceValue + eldritchValue + demonicValue;
        textComponent = textObjects[4].GetComponent<TMP_InputField>();
        float playerTotalValue = float.Parse(textComponent.text);
        if (playerTotalValue != totalValue)
        {
            var image = textObjects[0].GetComponent<Image>();
            image.color = Color.red;
            image = textObjects[1].GetComponent<Image>();
            image.color = Color.red;
            image = textObjects[2].GetComponent<Image>();
            image.color = Color.red;
            image = textObjects[3].GetComponent<Image>();
            image.color = Color.red;
            image = textObjects[4].GetComponent<Image>();
            image.color = Color.red;
            canContinue = false;
        }
        else if (quantumTaxEvasion == null)
        {
            canContinue = false;
        }
        else if (fabricManipulator  == null)
        {
            canContinue = false;
        }
        else if (legalEntityBinding == null)
        {
            canContinue = false;
        }
        else if (totalValue == 0)
        {
            canContinue = false;
        }
        else
        {
            var image = textObjects[0].GetComponent<Image>();
            image.color = Color.green;
            image = textObjects[1].GetComponent<Image>();
            image.color = Color.green;
            image = textObjects[2].GetComponent<Image>();
            image.color = Color.green;
            image = textObjects[3].GetComponent<Image>();
            image.color = Color.green;
            image = textObjects[4].GetComponent<Image>();
            image.color = Color.green;
            this.responseSheet.quantumTaxEvasion = this.quantumTaxEvasion;
            this.responseSheet.fabricManipulator = this.fabricManipulator;
            this.responseSheet.legalEntityBinding = this.legalEntityBinding;
            canContinue = true;
        }


    }

}
