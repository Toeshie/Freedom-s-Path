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
    [SerializeField] private GameObject dedication;
    [SerializeField] private GameObject role1;
    [SerializeField] private GameObject role2;
    [SerializeField] private GameObject gameProgrammer;
    [SerializeField] private GameObject gameArtist;
    [SerializeField] private GameObject creditsTitle;
   
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
        yield return new WaitForSeconds(19f);
        SceneManager.LoadScene("Main Menu");
    }

    private IEnumerator Credits()
    {
        yield return new WaitForSeconds(7f);
        AudioManager.Instance.FadeOutVolumeOverTime();
        role1.SetActive(true);
        role2.SetActive(true);
        gameArtist.SetActive(true);
        gameProgrammer.SetActive(true);
        creditsTitle.SetActive(true);
    }

    private IEnumerator CreditsTimer()
    {
        yield return new WaitForSeconds(5f);
        creditsFrame.SetActive(true);
        dedication.SetActive(true);
        StartCoroutine(Credits());
    }
}
