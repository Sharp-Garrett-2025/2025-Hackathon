using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitLogic : MonoBehaviour
{
    public GameObject confirmationMenu;

    void Start()
    {
        confirmationMenu.SetActive(false);
    }

    public void OnQuitButtonPressed()
    {
        confirmationMenu.SetActive(true);
    }

    public void OnYesButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnNoButtonPressed()
    {
        confirmationMenu.SetActive(false);
    }
}
