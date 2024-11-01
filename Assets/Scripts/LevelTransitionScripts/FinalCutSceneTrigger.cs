using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class FinalCutSceneTrigger : MonoBehaviour
{
    [SerializeField] private GameObject creditsFrame;
    [SerializeField] private Movement playerReference;
    [SerializeField] private GameObject dedication;
    [SerializeField] private GameObject role1;
    [SerializeField] private GameObject role2;
    [SerializeField] private GameObject gameProgrammer;
    [SerializeField] private GameObject gameArtist;
    [SerializeField] private GameObject creditsTitle;
    [SerializeField] private float creditsToStart = 5f;
    [SerializeField] private float creditsTimeOnScreen = 7f;
    [SerializeField] private float timeToMainMenu = 20f;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InventoryManager.instance.FinalCutsceneConditions();
            playerReference.SetCanMove(false);
            StartCoroutine(CreditsTimer());
            StartCoroutine(BackToMainMenu());
        }
    }

    private IEnumerator BackToMainMenu()
    {
        yield return new WaitForSeconds(timeToMainMenu);
        SceneManager.LoadScene("Main Menu");
    }

    private IEnumerator Credits()
    {
        yield return new WaitForSeconds(creditsTimeOnScreen);
        role1.SetActive(true);
        role2.SetActive(true);
        gameArtist.SetActive(true);
        gameProgrammer.SetActive(true);
        creditsTitle.SetActive(true);
    }

    private IEnumerator CreditsTimer()
    {
        yield return new WaitForSeconds(creditsToStart);
        creditsFrame.SetActive(true);
        dedication.SetActive(true);
        StartCoroutine(Credits());
    }
}
