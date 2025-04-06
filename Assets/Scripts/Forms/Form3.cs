using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Form3 : AbstractForm
{

    public ToggleGroup catgirlGroup;
    public ToggleGroup realityManipulationGroup;
    public bool? pocketHoleTaxes = null;
    public bool? catGirlGambling = null;
    public float Black, Red, BlackRedTotal, shitCoin, quantTrade, shitQuantTotal;


    public Image CatgirlImage;

    void Start()
    {
        if (responseSheet == null)
            responseSheet = GameObject.Find("ResponseSheet").GetComponent<ResponseSheet>();
        canContinue = false;
        Black = 0.0f;
        Red = 0.0f;
        BlackRedTotal = 0.0f;
        defaultColor = CatgirlImage.color;
    }

    public void CatGirlGambling(bool value)
    {
        TestYesOrNo(value, catgirlGroup);
        catGirlGambling = value;
    }

    public void RealityManipulationGroup(bool value)
    {
        TestYesOrNo(value, realityManipulationGroup);
        pocketHoleTaxes  = value;
    }

    public override void AnswerCheck()
    {
        TestStrings();
        var textComponent = textObjects[0].GetComponent<TMP_InputField>();
        Black = float.Parse(textComponent.text);
        Debug.Log(Black);
        textComponent = textObjects[1].GetComponent<TMP_InputField>();
        Red = float.Parse(textComponent.text);
        Debug.Log(Red);
        BlackRedTotal = Black + Red;
        Debug.Log(BlackRedTotal);
        textComponent = textObjects[3].GetComponent<TMP_InputField>();
        shitCoin = float.Parse(textComponent.text);
        Debug.Log(shitCoin);
        textComponent = textObjects[4].GetComponent<TMP_InputField>();
        quantTrade = float.Parse(textComponent.text);
        shitQuantTotal = shitCoin + quantTrade;
        Debug.Log(shitQuantTotal);
        // Player answered sums totals
        textComponent = textObjects[2].GetComponent<TMP_InputField>();
        float playerRedBlackTotal = float.Parse(textComponent.text);
        textComponent = textObjects[5].GetComponent<TMP_InputField>();
        float playerShitQuantTotal = float.Parse(textComponent.text);

        if (shitQuantTotal != playerShitQuantTotal && BlackRedTotal == playerRedBlackTotal)
        {
            var image = textObjects[5].GetComponent<Image>();
            image.color = Color.red;
            image = textObjects[3].GetComponent<Image>();
            image.color = Color.red;
            image = textObjects[4].GetComponent<Image>();
            image.color = Color.red;
            image = textObjects[0].GetComponent<Image>();
            image.color = Color.green;
            image = textObjects[1].GetComponent<Image>();
            image.color = Color.green;
            image = textObjects[2].GetComponent<Image>();
            image.color = Color.green;
            canContinue = false;
        }
        else if(BlackRedTotal != playerRedBlackTotal && shitQuantTotal == playerShitQuantTotal )
        {
            var image = textObjects[2].GetComponent<Image>();
            image.color = Color.red;
            image = textObjects[0].GetComponent<Image>();
            image.color = Color.red;
            image = textObjects[1].GetComponent<Image>();
            image.color = Color.red;
            image = textObjects[3].GetComponent<Image>();
            image.color = Color.green;
            image = textObjects[4].GetComponent<Image>();
            image.color = Color.green;
            image = textObjects[5].GetComponent<Image>();
            image.color = Color.green;
            canContinue = false;
        }
        else if (BlackRedTotal != playerRedBlackTotal || BlackRedTotal == 0)
        {
            var image = textObjects[2].GetComponent<Image>();
            image.color = Color.red;
            image = textObjects[0].GetComponent<Image>();
            image.color = Color.red;
            image = textObjects[1].GetComponent<Image>();
            image.color = Color.red;
            canContinue = false;
        }
        else if (shitQuantTotal != playerShitQuantTotal || shitQuantTotal == 0)
        {
            var image = textObjects[5].GetComponent<Image>();
            image.color = Color.red;
            image = textObjects[3].GetComponent<Image>();
            image.color = Color.red;
            image = textObjects[4].GetComponent<Image>();
            image.color = Color.red;
            canContinue = false;
        }
        else
        {
            var image = textObjects[2].GetComponent<Image>();
            image.color = Color.green;
            image = textObjects[5].GetComponent<Image>();
            image.color = Color.green;
            image = textObjects[0].GetComponent<Image>();
            image.color = Color.green;
            image = textObjects[1].GetComponent<Image>();
            image.color = Color.green;
            image = textObjects[3].GetComponent<Image>();
            image.color = Color.green;
            image = textObjects[4].GetComponent<Image>();
            image.color = Color.green;

            responseSheet.pocketHoleTaxes = this.pocketHoleTaxes;
            responseSheet.catGirlGambling = this.catGirlGambling;
            canContinue = true;
        }

    }
}
