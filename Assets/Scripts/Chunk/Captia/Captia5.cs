using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Captia5 : BasicCaptia
{
    public Button verifyButton;
    public GameObject questionCaptcha;
    public Button robotButton;
    public GameObject robotObject;
    public TMP_InputField inputField;

    new void Start()
    {
        verifyButton.onClick.AddListener(VerifyAnswer);
        robotButton.onClick.AddListener(EnableQuestionCaptcha);
        questionCaptcha.SetActive(false);
        base.Start();
    }

    void VerifyAnswer()
    {
        if (inputField.text == "2")
        {
            errorText.text = "Captcha verified successfully.";
            errorObject.SetActive(false);
            canContinue = true;
            inputField.interactable = false; // Disable the input field
            questionCaptcha.SetActive(false); // Disable the question captcha GameObject
        }
        else
        {
            errorText.text = "Incorrect answer. Please try again.";
            errorObject.SetActive(true);
            canContinue = false;
        }
        inputField.text = string.Empty; // Clear the input field
    }

    void EnableQuestionCaptcha()
    {
        questionCaptcha.SetActive(true); // Enabling the additional GameObject
        robotObject.SetActive(false);
        errorText.text = "Please answer the question before continuing";
        errorObject.SetActive(false);
    }
}
