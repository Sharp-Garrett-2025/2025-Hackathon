using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Captia2 : BasicCaptia
{
    public List<Button> buttons;
    public List<int> correctPattern;
    public Button checkPatternButton;
    public GameObject pictureCaptia;
    public Button robotButton; 
    public GameObject robotObject;

    private List<int> currentPattern;

    public override void SetErrorText()
    {
        errorText.text = "Please Verify that you are not a robot before continuing";
    }

    new void Start()
    {
        currentPattern = new List<int>();
        foreach (var button in buttons)
        {
            button.onClick.AddListener(() => OnButtonPressed(button));
        }
        checkPatternButton.onClick.AddListener(CheckPattern);
        robotButton.onClick.AddListener(EnablePictureCaptia); // Hooking up the new button
        pictureCaptia.SetActive(false); // Initially disable the GameObject
        base.Start();
    }


    void OnButtonPressed(Button button)
    {
        int index = buttons.IndexOf(button);
        currentPattern.Add(index);

        // Make the button not interactable after being pressed
        button.interactable = false;
    }

    void CheckPattern()
    {
        if (currentPattern.Count == correctPattern.Count)
        {
            if (IsPatternCorrect())
            {
                Debug.Log("Correct pattern!");
                canContinue = true;
                errorObject.SetActive(false);
            }
            else
            {
                ResetButtons();
            }
            currentPattern.Clear();
        }
        else
        {
            Debug.Log("Pattern length mismatch.");
            currentPattern.Clear();
            ResetButtons();
        }
    }

    bool IsPatternCorrect()
    {
        List<int> sortedCurrentPattern = new List<int>(currentPattern);
        List<int> sortedCorrectPattern = new List<int>(correctPattern);
        sortedCurrentPattern.Sort();
        sortedCorrectPattern.Sort();

        for (int i = 0; i < sortedCorrectPattern.Count; i++)
        {
            if (sortedCurrentPattern[i] != sortedCorrectPattern[i])
            {
                return false;
            }
        }
        return true;
    }

    void ResetButtons()
    {
        foreach (var button in buttons)
        {
            // Assuming you have a method to reset the button state
            button.interactable = true; // Example of resetting button state
        }
        Debug.Log("Pattern incorrect. Buttons reset.");
    }

    void EnablePictureCaptia()
    {
        pictureCaptia.SetActive(true); // Enabling the additional GameObject
        robotObject.SetActive(false);
        errorText.text = "Please finish Captcha before continuing";
        errorObject.SetActive(false);
    }
}
