using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    public void PlayGame()
    {
        SceneManager.LoadScene("1º Level");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    private void OnEnable()
    {
        startButton.Select();
    }
}
