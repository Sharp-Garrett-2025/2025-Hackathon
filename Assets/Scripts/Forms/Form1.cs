using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Form1 : AbstractForm
{
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public ToggleGroup petToggleGroup;
    public ToggleGroup travelToggleGroup;
    public ToggleGroup categoryToggleGroup;
    public ToggleGroup quantumToggleGroup;


    public bool? hasPet = null;
    public bool? travelThroughEconomicZone = null;
    public bool? hasQuantum = null;
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

    public void TravelThroughEconomicZone(bool value)
    {
        TestYesOrNo(value, travelToggleGroup);
        travelThroughEconomicZone = value;
    }

    public void PetToggleGroup(bool value)
    {
        TestYesOrNo(value, petToggleGroup);
        hasPet = value;
    }

    public void QuantumToggleGroup(bool value)
    {
        TestYesOrNo(value, quantumToggleGroup);
        hasQuantum = value;
    }

    public void CategoryToggleGroup(string value)
    {
        category = value;
    }

    public override void AnswerCheck()
    {
        userName = inputField1.text;
        location = inputField2.text;
        if (hasPet == null)
        {
            canContinue = false;
        }
        else if (travelThroughEconomicZone == null)
        {
            canContinue = false;
        }
        else if (hasQuantum == null)
        {
            canContinue = false;
        }
        else if (category == "")
        {
            canContinue = false;
        }
        else if (inputField1.text == "" || inputField2.text == "")
        {
            canContinue = false;
        }
        else
        {
            responseSheet.Name = this.userName;
            responseSheet.category = this.category;
            responseSheet.location = this.location;
            responseSheet.hasPet = this.hasPet;
            responseSheet.travelThroughEconomicZone = this.travelThroughEconomicZone;
            responseSheet.hasQuantum = this.hasQuantum;
            canContinue = true;
        }

    }

    public override void OnFormPressed()
    {
        AnswerCheck();
        if (canContinue)
        {
            Debug.Log("Proceeding to the next chunk...");
            basicChunk.EndChunk();
        }
        else
        {
            Debug.Log("Please complete the current chunk before proceeding.");
        }
    }

}
