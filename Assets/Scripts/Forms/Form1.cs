using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Form1 : AbstractForm
{
    public ResponseSheet responseSheet;
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public TMP_InputField inputField3;
    public ToggleGroup petToggleGroup;
    public ToggleGroup travelToggleGroup;
    public ToggleGroup categoryToggleGroup;
    public Color defaultColor;
    public bool? hasPet = null;
    public bool? travelThroughEconomicZone = null;
    public Image yesPet;
    public Image noPet;
    public string userName;
    public string category = "";
    public string location;

    // Start is called before the first frame update
    void Start()
    {
        if (responseSheet == null)
            responseSheet = GameObject.Find("ResponseSheet").GetComponent<ResponseSheet>();
        defaultColor = yesPet.color;
        canContinue = false;
        Debug.Log("Cancontinue: " + canContinue);
    }

    public void ChangePetVarible(bool value)
    {
        hasPet = value;
        Debug.Log("Has a pet:" + hasPet);
        if (hasPet == true)
        {
            yesPet.color = Color.green;
            noPet.color = defaultColor;
        }
        else
        {
            noPet.color = Color.red;
            yesPet.color = defaultColor;
        }

    }

    public void ChangeTravelThroughEconomicZone(bool value)
    {
        travelThroughEconomicZone = value;
        if (travelThroughEconomicZone == true)
        {
            travelToggleGroup.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.green;
            travelToggleGroup.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().color = defaultColor;
        }
        else
        {
            travelToggleGroup.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
            travelToggleGroup.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = defaultColor;
        }
        Debug.Log("Travel through economic zone:" + travelThroughEconomicZone);
    }
    public override void AnswerCheck()
    {
        name = inputField1.text;
        Debug.Log(name);
        location = inputField2.text;
        Debug.Log(location);
        //category = inputField3.text;
        //Debug.Log(category);
        if (hasPet == null)
        {
            canContinue = false;
        }
        else if (inputField1.text == "" || inputField2.text == "" || inputField3.text == "")
        {
            canContinue = false;
        }
        else if (travelThroughEconomicZone == null)
        {
            canContinue = false;
        }
        else if (category == "")
        {
            canContinue = false;
        }
        else
        {
            responseSheet.name = this.name;
            responseSheet.category = this.category;
            responseSheet.location = this.location;
            responseSheet.hasPet = this.hasPet;
            responseSheet.travelThroughEconomicZone = this.travelThroughEconomicZone;
            canContinue = true;
        }

    }


    public override void OnFormPressed()
    {
        AnswerCheck();
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
