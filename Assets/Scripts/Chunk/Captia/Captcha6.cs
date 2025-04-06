using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Captcha6 : BasicCaptia
{
    public Button checkPatternButton;
    public GameObject textCaptcha;
    public Button robotButton;
    public GameObject robotObject;
    public string correctString;
    public TMP_InputField inputField;
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    private int currentWaypointIndex = 0;
    private bool isMoving = false;

    new void Start()
    {
        checkPatternButton.onClick.AddListener(CheckPattern);
        robotButton.onClick.AddListener(EnableTextCaptcha);
        textCaptcha.SetActive(false);
        base.Start();
    }

    void Update()
    {
        if (isMoving)
        {
            MoveTextCaptcha();
        }
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
            isMoving = false; // Stop moving the text captcha
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
        isMoving = true; // Start moving the text captcha
    }

    void MoveTextCaptcha()
    {
        if (waypoints.Length == 0) return;

        textCaptcha.transform.position = Vector3.MoveTowards(textCaptcha.transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(textCaptcha.transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}
