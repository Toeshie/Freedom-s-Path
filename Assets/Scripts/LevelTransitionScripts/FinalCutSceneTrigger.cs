using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class FinalCutSceneTrigger : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer = null;
    [SerializeField] private GameObject creditsFrame;
    [SerializeField] private Movement playerReference;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            videoPlayer.Play();
            playerReference.SetCanMove(false);
            StartCoroutine(CreditsTimer());
            StartCoroutine(BackToMainMenu());
        }
    }

    private IEnumerator BackToMainMenu()
    {
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene("Main Menu");
    }

    private IEnumerator CreditsTimer()
    {
        yield return new WaitForSeconds(6f);
        creditsFrame.SetActive(true);
        
    }
}
