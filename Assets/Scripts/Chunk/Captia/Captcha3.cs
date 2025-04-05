using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Captcha3 : BasicCaptia
{
    public Button checkPatternButton;
    public GameObject textCaptcha;
    public Button robotButton;
    public GameObject robotObject;
    public string correctString;
    public TMP_InputField inputField;

    new void Start()
    {
        correctString = "mdx8n7"; 
        checkPatternButton.onClick.AddListener(CheckPattern);
        robotButton.onClick.AddListener(EnableTextCaptcha);
        textCaptcha.SetActive(false);
        base.Start();
    }

    void CheckPattern()
    {
        if (inputField.text == correctString)
        {
            errorText.text = "Captcha verified successfully.";
            errorObject.SetActive(false);
            canContinue = true;
            inputField.interactable = false; // Disable the input field
            textCaptcha.SetActive(false); // Disable the text captcha GameObject
        }
        else
        {
            errorText.text = "Incorrect Captcha. Please try again.";
            errorObject.SetActive(true);
            canContinue = false;
        }
        inputField.text = string.Empty; // Clear the input field
    }

    void EnableTextCaptcha()
    {
        textCaptcha.SetActive(true); // Enabling the additional GameObject
        robotObject.SetActive(false);
        errorText.text = "Please finish Captcha before continuing";
        errorObject.SetActive(false);
    }
}
