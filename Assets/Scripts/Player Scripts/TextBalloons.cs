using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBalloons : MonoBehaviour
{
    //NOT FINAL CODE TO BE CHANGED!!!!!!!!!!!!!!!!!!!! PLACEHOLDER CODE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    [SerializeField] private float balloonDisplayDuration = 3.5f;
    [SerializeField] private GameObject balloon1;
    [SerializeField] private GameObject balloon3;
    [SerializeField] private GameObject balloon4;
    [SerializeField] private GameObject balloon5;
    [SerializeField] private AudioSource balloonsAudioSource = null;
    [SerializeField] private AudioClip balloonsAudioClip;
    

    private bool balloon1flag = false;
    
    private bool balloon3flag = false;

    private bool balloon4flag = false;

    private bool balloon5flag = false;

    private bool isBalloonOnScreen = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Balloon1") && !balloon1flag && !isBalloonOnScreen)
        {
            balloon1flag = true;
            isBalloonOnScreen = true;
            balloonsAudioSource.PlayOneShot(balloonsAudioClip);
            StartCoroutine(ActivateAndDeactivateBalloon1());
        }
        
       
        if (other.gameObject.CompareTag("Balloon3") && !balloon3flag && !isBalloonOnScreen)
        {
            balloon3flag = true;
            isBalloonOnScreen = true;
            balloonsAudioSource.PlayOneShot(balloonsAudioClip);
            StartCoroutine(ActivateAndDeactivateBalloon3());
        }
        
        if (other.gameObject.CompareTag("Balloon4") && !balloon4flag && !isBalloonOnScreen)
        {
            balloon4flag = true;
            isBalloonOnScreen = true;
            balloonsAudioSource.PlayOneShot(balloonsAudioClip);
            StartCoroutine(ActivateAndDeactivateBalloon4());
        }
        if (other.gameObject.CompareTag("Balloon5") && !balloon5flag && !isBalloonOnScreen)
        {
            balloon5flag = true;
            isBalloonOnScreen = true;
            balloonsAudioSource.PlayOneShot(balloonsAudioClip);
            StartCoroutine(ActivateAndDeactivateBalloon5());
        }
        
        
    }
    private IEnumerator ActivateAndDeactivateBalloon1()
    {
        balloon1.SetActive(true);
        yield return new WaitForSeconds(balloonDisplayDuration); 
        balloon1.SetActive(false);
        isBalloonOnScreen = false;
    }
    
    private IEnumerator ActivateAndDeactivateBalloon3()
    {
        balloon3.SetActive(true);
        yield return new WaitForSeconds(balloonDisplayDuration); 
        balloon3.SetActive(false);
        isBalloonOnScreen = false;
    }
    
    private IEnumerator ActivateAndDeactivateBalloon4()
    {
        balloon4.SetActive(true);
        yield return new WaitForSeconds(balloonDisplayDuration); 
        balloon4.SetActive(false);
        isBalloonOnScreen = false;
    }
    
    private IEnumerator ActivateAndDeactivateBalloon5()
    {
        balloon5.SetActive(true);
        yield return new WaitForSeconds(balloonDisplayDuration); 
        balloon5.SetActive(false);
        isBalloonOnScreen = false;
    }
    
   
    //NOT FINAL CODE TO BE CHANGED!!!!!!!!!!!!!!!!!!!! PLACEHOLDER CODE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
}