using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Captia1 : BasicCaptia
{
    public override void SetErrorText()
    {
        errorText.text = "Please Verify that you are not a robot before continuing";
    }
    public void OnCaptiaPressed()
    {
        canContinue = true;
    }

}
