
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private AudioSource menuAudioSource;
    [SerializeField] private GameObject inventario = null;
    [SerializeField] GameObject pauseMenu = null;
    private bool isPaused;
    [SerializeField] private AudioClip buttonClickAudio = null;
    public static PauseMenu Instance;
   

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
        
        
       menuAudioSource = GetComponent<AudioSource>();
       ResumeGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
            PlayButtonClick();
        }
        
        if (Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame)
        {
            TogglePause();
            PlayButtonClick();
        }
    }

    private void TogglePause()
    {
        if (isPaused)
        {
            inventario.SetActive(false);
            ResumeGame();
        }
        else
        {
            inventario.SetActive(false);
            PauseGame();
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        //PlayButtonClick();
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    private void PlayButtonClick()
    {
        menuAudioSource.PlayOneShot(buttonClickAudio);
    }
}