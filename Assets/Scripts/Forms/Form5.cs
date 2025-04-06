using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Form5 : AbstractForm
{
    public bool? hasPet = null;
    public bool? travelThroughEconomicZone= null;
    public bool? hasQuantum = null;
    public bool? clickFruad = null;
    public bool? temporalInformation = null;
    public bool? fabricManipulator = null;
    public bool? quantumTaxEvasion = null;
    public bool? legalEntityBinding = null;
    public bool? pocketHoleTaxes = null;
    public bool? catGirlGambling = null;
    public bool? lieTaxes = null;
    public bool? demensionEnt= null;
    public int passPoints = 0;
    public int maxPassPoints;

    public ToggleGroup petToggleGroup;
    public ToggleGroup travelToggleGroup;
    //public ToggleGroup categoryToggleGroup;
    public ToggleGroup quantumToggleGroup;
    public ToggleGroup dataGroup;
    public ToggleGroup clickFruadGroup;
    public ToggleGroup entityGroup;
    public ToggleGroup catgirlGroup;
    public ToggleGroup realityManipulationGroup;
    public ToggleGroup taxGroup;
    public ToggleGroup soulGroup;
    public ToggleGroup iAmGroup;
    public ToggleGroup lieTaxesGroup;
    public ToggleGroup DemensionalEntityGroup;

    public Image clickFruadImage;

    void Start()
    {
        if (responseSheet == null)
            responseSheet = GameObject.Find("ResponseSheet").GetComponent<ResponseSheet>();
        defaultColor = clickFruadImage.color;
        canContinue = false;
        maxPassPoints = Random.Range(4, 9);
    }

    string category = "";
    string demensionalEntity = "";
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
        temporalInformation = value;
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

    public void LieTaxes(bool value)
    {
        TestYesOrNo(value, lieTaxesGroup);
        lieTaxes = value;
    }

    public void DemensionalEntity(bool value)
    {
        TestYesOrNo(value, DemensionalEntityGroup);
        demensionEnt = value;
    }

    public override void AnswerCheck()
    {
        passPoints++;
        if (hasPet != null | travelThroughEconomicZone != null | hasQuantum != null | clickFruad != null |
            temporalInformation != null | fabricManipulator != null | quantumTaxEvasion != null | legalEntityBinding
            != null | pocketHoleTaxes != null | catGirlGambling != null | lieTaxes != null | demensionEnt != null)
        {
            canContinue = true;
        }

        if (this.clickFruad != responseSheet.clickFruad)
        {
            canContinue = false;
            clickFruadGroup.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
            clickFruadGroup.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
        }

        if (this.temporalInformation != responseSheet.temporalInformation)
        {
            canContinue = false;
            entityGroup.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
            entityGroup.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
        }

        if (fabricManipulator != responseSheet.fabricManipulator)
        {
            canContinue = false;
            soulGroup.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
            soulGroup.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
        }

        if (this.quantumTaxEvasion != responseSheet.quantumTaxEvasion)
        {
            canContinue = false;
            taxGroup.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
            taxGroup.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
        }

        if (this.legalEntityBinding != responseSheet.legalEntityBinding)
        {
            canContinue = false;
            iAmGroup.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
            iAmGroup.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
        }

        if (this.pocketHoleTaxes != responseSheet.pocketHoleTaxes)
        {
            canContinue = false;
            realityManipulationGroup.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
            realityManipulationGroup.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
        }

        if (this.catGirlGambling != responseSheet.catGirlGambling)
        {
            canContinue = false;
            catgirlGroup.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
            catgirlGroup.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
        }
        if (lieTaxes == true)
        {
            catgirlGroup.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.green;
        }
        if (lieTaxes == false)
        {
            catgirlGroup.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
        }
        if (demensionEnt == null)
        {
            canContinue = false;
        }
        if (passPoints == maxPassPoints )
        {
            canContinue = true;
        }
    }
}
